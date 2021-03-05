using JetBrains.Annotations;

namespace System
{
    partial class BooleanExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Returns <see langword="false"/> if a <see cref="Nullable"/>&lt;<see cref="bool"/>&gt; is <see langword="null"/>.
        /// <para>
        ///     Useful when trying to access a <see cref="bool"/> member inside of a null-coalescing member expression
        ///     (thus not increasing cyclomatic complexity).
        /// </para>
        ///     <code>if (obj?.Sub?.BooleanProperty ?? false) { }</code>
        ///     becomes
        ///     <code>if (obj?.Sub?.BooleanProperty.OrFalse()) { }</code>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static bool OrFalse([CanBeNull] this bool? value) => value.HasValue && value.Value;
    }
}
