﻿using System.Linq;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    //https://stackoverflow.com/questions/7889228/how-to-prevent-reflectiontypeloadexception-when-calling-assembly-gettypes

    partial class AssemblyExt
    {
        /// <summary>
        ///     Get the loadable types in an assembly incase a <see cref="ReflectionTypeLoadException"/> occurs.
        /// </summary>
        /// <param name="assembly">Assembly to search for types.</param>
        /// <returns>Array of loadable types.</returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull]
        [Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage] // Jon Skeet wrote it, we're good
        public static Type[] GetLoadableTypes([NotNull] this Assembly assembly)
        {
            if (assembly == null) throw Exceptions.NullRef();
            Type[] result;

            try
            {
                result = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                result = ex.Types?.Where(t => t != null).ToArray() ?? Array.Empty<Type>();
            }

            return result;
        }
    }
}
