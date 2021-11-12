using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    /// <summary>
    ///     (Opinionated)
    ///     Facade for extracting C# type names from text input.
    /// </summary>
    // https://stackoverflow.com/questions/20532691/how-to-parse-c-sharp-generic-type-names
    public class TypeName
    {
        private readonly List<ArrayDimension> _arrayDimensions = new List<ArrayDimension>();
        private readonly List<TypeName> _typeArguments = new List<TypeName>();
        private string _name;
        private bool _isGeneric;

        /// <summary>
        ///     Name of the type. Will exclude generic arguments.
        /// </summary>
        public string Name => _name;

        /// <summary>
        ///     Determines if the type appears to be generic.
        /// </summary>
        public bool IsGeneric => _isGeneric;

        /// <summary>
        ///     Determines if the type appears to be open generic.
        /// </summary>
        public bool IsOpenGeneric => TypeArguments.Any() && TypeArguments.All(a => a.Name == String.Empty);

        /// <summary>
        ///     Determines if the type appears to be any sort of array type.
        /// </summary>
        public bool IsArray => ArrayDimensions.Count > 0;

        /// <summary>
        ///     Determines if the input contains the nullable shorthand operator ("?").
        /// </summary>
        public bool ContainsNullableShorthand => Name.Contains("?");

        /// <summary>
        ///     Returns the array dimension info from the text input.
        /// </summary>
        public IReadOnlyList<ArrayDimension> ArrayDimensions => _arrayDimensions;

        /// <summary>
        ///     Returns generic arguments information from the type name.
        /// </summary>
        public IReadOnlyList<TypeName> TypeArguments => _typeArguments;

        private TypeName() { }

        /// <summary>
        ///     Parse the text input into an instance of <see cref="TypeName"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static TypeName Parse([NotNull] string name)
        {
            int pos = 0;
            bool dummy;
            return ParseImpl(name, ref pos, out dummy);
        }

        /// <summary>
        ///     Attempt to parse the text input into an instance of <see cref="TypeName"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [PublicAPI]
        public static bool CanParse(string name, out TypeName value)
        {
            try
            {
                value = Parse(name);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        /// <summary>
        ///     If the type input has generic arguments, those will be returned as well.
        /// </summary>
        /// <inheritdoc />
        public override string ToString()
        {
            string str = Name;
            if (IsGeneric)
                str += "<" + string.Join(", ", _typeArguments.Select(tn => tn.ToString()).Select(s => s.Trim())) + ">";
            foreach (ArrayDimension d in _arrayDimensions)
                str += d.ToString();
            return str;
        }

        private static TypeName ParseImpl(string name, ref int pos, out bool listTerminated)
        {
            if (name == null) throw Exceptions.ArgumentNull(nameof(name));

            StringBuilder sb = new StringBuilder();
            TypeName tn = new TypeName();
            listTerminated = true;

            TypeName TrimResult(TypeName value)
            {
                value._name = value.Name?.Trim();
                return value;
            }

            while (pos < name.Length)
            {
                char c = name[pos++];
                switch (c)
                {
                    case ',':
                        if (tn.Name == null)
                            tn._name = sb.ToString();
                        listTerminated = false;
                        return TrimResult(tn);
                    case '>':
                        if (tn.Name == null)
                            tn._name = sb.ToString();
                        listTerminated = true;
                        return TrimResult(tn);
                    case '<':
                        {
                            tn._name = sb.ToString();
                            tn._isGeneric = true;
                            sb.Length = 0;
                            bool terminated = false;
                            while (!terminated)
                                tn._typeArguments.Add(ParseImpl(name, ref pos, out terminated));
                            var t = name[pos - 1];
                            if (t == '>')
                                continue;
                            else
                                throw new FormatException("Missing closing > of generic type list.").WithSource();
                        }
                    case '[':
                        ArrayDimension d = new ArrayDimension();
                        tn._arrayDimensions.Add(d);
                    analyzeArrayDimension: //label for looping over multidimensional arrays
                        if (pos < name.Length)
                        {
                            char nextChar = name[pos++];
                            switch (nextChar)
                            {
                                case ']':
                                    continue; //array specifier terminated
                                case ',': //multidimensional array
                                    d.Dimensions++;
                                    goto analyzeArrayDimension;
                                default:
                                    throw new FormatException(@"Expecting ""]"" or "","" after ""["" for array specifier but encountered """ + nextChar + @""".").WithSource();
                            }
                        }
                        throw new FormatException("Expecting ] or , after [ for array type, but reached end of string.").WithSource();
                    default:
                        sb.Append(c);
                        continue;
                }
            }
            if (tn.Name == null)
                tn._name = sb.ToString();
            return TrimResult(tn);
        }

        /// <summary>
        ///     Parsed array dimension information for a <see cref="TypeName"/> instance.
        /// </summary>
        public class ArrayDimension
        {
            /// <summary>
            ///     The number of dimensions specified in the array type.
            /// </summary>
            public int Dimensions;

            /// <summary>
            ///     Instantiate a new instance of <see cref="ArrayDimension" />.
            /// </summary>
            public ArrayDimension()
            {
                Dimensions = 1;
            }

            /// <inheritdoc />
            public override string ToString()
            {
                return "[" + new String(',', Dimensions - 1) + "]";
            }
        }
    }
}
