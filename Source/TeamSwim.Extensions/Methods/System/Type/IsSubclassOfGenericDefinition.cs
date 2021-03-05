//using JetBrains.Annotations;
//using ExcludeFromCodeCoverage = System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute;

//namespace System
//{
//    //TODO: Not a great name, uncomment when better name is determined

//    partial class TypeExt
//    {
//        /// <summary>
//        ///     Determines if a given type is a subclass of a generic definition type.
//        /// </summary>
//        /// <param name="type">The generic type to check for compatibility.</param>
//        /// <param name="genericTypeDefinition">The generic definition type being checked for compatibility with the passed type.</param>
//        /// <returns><see langword="true"/> if the type is derived from the generic definition. Otherwise, <see langword="false"/>.</returns>
//        [PublicAPI]
//        [Pure, ExcludeFromCodeCoverage]
//        public static bool IsSubclassOfGenericDefinition(
//            [NotNull] this Type type,
//            [NotNull] Type genericTypeDefinition)
//        {
//            Type[] _;
//            var result = IsSubclassOfGenericDefinition(type, genericTypeDefinition, out _);
//            return result;
//        }

//        /// <summary>
//        ///     Determines if a given type is a subclass of a generic definition type.
//        /// </summary>
//        /// <param name="type">The generic type to check for compatibility.</param>
//        /// <param name="genericTypeDefinition">The generic definition type being checked for compatibility with the passed type.</param>
//        /// <param name="genericTypes">The generic type arguments of the specified type.</param>
//        /// <returns><see langword="true"/> if the type is derived from the generic definition. Otherwise, <see langword="false"/>.</returns>
//        [PublicAPI]
//        [Pure]
//        public static bool IsSubclassOfGenericDefinition( //TODO: Is there a better way to do this?
//            [NotNull] this Type type,
//            [NotNull] Type genericTypeDefinition,
//            [ItemNotNull] out Type[] genericTypes)
//        {
//            genericTypes = null;

//            if (type == null) throw Exceptions.ArgumentNull(nameof(type));
//            if (genericTypeDefinition == null) throw Exceptions.ArgumentNull(nameof(genericTypeDefinition));

//            if (!genericTypeDefinition.IsGenericTypeDefinition) return false;
//            if (type == genericTypeDefinition) return true;

//            var name = $"{genericTypeDefinition.Namespace}.{genericTypeDefinition.Name}";

//            if (genericTypeDefinition.IsInterface)
//            {
//                foreach (var i in type.GetInterfaces())
//                {
//                    var iName = $"{i.Namespace}.{i.Name}";

//                    if (name.Equals(iName, StringComparison.Ordinal))
//                    {
//                        genericTypes = i.GetGenericArguments();

//                        return true;
//                    }
//                }

//                return false;
//            }
//            else
//            {
//                var baseType = type;

//                do
//                {
//                    var iName = $"{baseType.Namespace ?? "System"}.{baseType.Name}";

//                    if (name.Equals(iName, StringComparison.Ordinal))
//                    {
//                        genericTypes = baseType.GetGenericArguments();

//                        return true;
//                    }

//                    baseType = baseType.BaseType;

//                } while (baseType != typeof(object) && baseType != null);

//                return false;
//            }
//        }
//    }
//}
