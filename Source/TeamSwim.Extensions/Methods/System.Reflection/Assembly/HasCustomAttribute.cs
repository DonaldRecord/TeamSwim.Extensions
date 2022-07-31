using JetBrains.Annotations;

namespace System.Reflection
{
    partial class AssemblyExt
    {
        /// <summary>
        ///     Determines if the specified <paramref name="assembly"/> has a custom attribute of type <typeparamref name="TAttribute"/>.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to search for.</typeparam>
        /// <param name="assembly">Assembly to check.</param>
        /// <param name="attribute">The attribute instance, if found.</param>
        /// <returns><see langword="true"/> if the assembly contains the specified attribute. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        [ContractAnnotation("attribute:null=>false;attribute:notnull=>true")]
        public static bool HasCustomAttribute<TAttribute>(this Assembly assembly, out TAttribute attribute) where TAttribute : Attribute
        {
            attribute = assembly.GetCustomAttribute<TAttribute>();
            return attribute != null;
        }

        /// <summary>
        ///     Determines if the specified <paramref name="assembly"/> has a custom attribute of type <typeparamref name="TAttribute"/>.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to search for.</typeparam>
        /// <param name="assembly">Assembly to check.</param>
        /// <returns><see langword="true"/> if the assembly contains the specified attribute. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool HasCustomAttribute<TAttribute>(this Assembly assembly) where TAttribute : Attribute =>
            assembly.HasCustomAttribute<TAttribute>(out _);
    }
}
