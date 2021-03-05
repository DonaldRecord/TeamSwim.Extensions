using JetBrains.Annotations;

namespace System
{
    partial class EnumExt
    {
        /// <summary>
        ///     Returns <see langword="true"/> if the <see cref="Enum"/> <paramref name="value"/> 
        ///     has all of the <paramref name="flags"/> specified.
        /// </summary>
        /// <param name="value">The <see cref="Enum"/> value.</param>
        /// <param name="flags">The <see cref="Enum"/> flags to check for.</param>
        /// <returns><see langword="true"/> if the Enum has all of the flags specified. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException">One of the <paramref name="flags" /> is a different type than <paramref name="value"/>.</exception>
        [PublicAPI]
        [Pure]
        public static bool HasAllFlags([NotNull] this Enum value, [NotNull, ItemNotNull] params Enum[] flags)
        {
            foreach (var f in flags)
            {
                if (!value.HasFlag(f)) return false;
            }

            return true;
        }
    }
}
