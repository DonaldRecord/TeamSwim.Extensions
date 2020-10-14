using JetBrains.Annotations;

namespace System
{
    partial class BooleanExt
    {
        /// <summary>
        ///     Returns <see langword="false"/> if a <see cref="Nullable"/>&lt;<see cref="bool"/>&gt; is <see langword="null"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure, PublicAPI]
        public static bool OrFalse([CanBeNull] this bool? value) => value.HasValue && value.Value;
    }
}
