using JetBrains.Annotations;

namespace System
{
    partial class EnumExt
    {
        /// <summary>
        ///     Determines if the <see cref="Enum"/> <paramref name="value"/> 
        ///     has any of the <see cref="Enum"/> <paramref name="flags"/>.
        /// </summary>
        /// <param name="value">Enum value to check for.</param>
        /// <param name="flags">Flags to enumerate and check for.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">One of the <paramref name="flags" /> is a different type than the <paramref name="value"/>.</exception>
        [PublicAPI]
        [Pure]
        public static bool HasAnyFlag(this Enum value, params Enum[] flags)
        {
            foreach (var f in flags)
            {
                if (value.HasFlag(f)) return true;
            }

            return false;
        }
    }
}
