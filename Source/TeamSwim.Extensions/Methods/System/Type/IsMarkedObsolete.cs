using JetBrains.Annotations;
using System.Reflection;

namespace System
{
    public static partial class TypeExt
    {
        /// <summary>
        ///     Determines if the specified <paramref name="type"/> is marked obsolete via the use of <see cref="ObsoleteAttribute"/>.
        /// </summary>
        /// <param name="type">The type to check for obsolescence.</param>
        /// <param name="obsoleteAttribute">The obsolete attribute, if any.</param>
        /// <returns><see langword="true"/> if the type is marked obsolete. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded. </exception>
        /// <exception cref="AmbiguousMatchException">More than one of the requested attributes was found. </exception>
        [PublicAPI]
        [Pure, ContractAnnotation("obsoleteAttribute:null=>false;obsoleteAttribute:notnull=>true")]
        public static bool IsMarkedObsolete([NotNull] this Type type, out ObsoleteAttribute obsoleteAttribute)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            obsoleteAttribute = type.GetCustomAttribute<ObsoleteAttribute>();
            var result = obsoleteAttribute != null;
            return result;
        }

        /// <summary>
        ///     Determines if the specified <paramref name="type"/> is marked obsolete via the use of <see cref="ObsoleteAttribute"/>.
        /// </summary>
        /// <param name="type">The type to check for obsolescence.</param>
        /// <param name="message">The message of the obsolete attribute, if any.</param>
        /// <returns><see langword="true"/> if the type is marked obsolete. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded. </exception>
        /// <exception cref="AmbiguousMatchException">More than one of the requested attributes was found. </exception>
        [PublicAPI]
        [Pure, ContractAnnotation("message:null=>false")]
        public static bool IsMarkedObsolete([NotNull] this Type type, out string message)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var obsoleteAttribute = type.GetCustomAttribute<ObsoleteAttribute>();
            var result = obsoleteAttribute != null;
            message = obsoleteAttribute?.Message;
            return result;
        }

        /// <summary>
        ///     Determines if the specified <paramref name="type"/> is marked obsolete via the use of <see cref="ObsoleteAttribute"/>.
        /// </summary>
        /// <param name="type">The type to check for obsolescence.</param>
        /// <returns><see langword="true"/> if the type is marked obsolete. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        public static bool IsMarkedObsolete([NotNull] this Type type) => type.IsMarkedObsolete(out ObsoleteAttribute _);
    }
}
