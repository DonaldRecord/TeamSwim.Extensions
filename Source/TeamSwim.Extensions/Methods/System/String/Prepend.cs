using JetBrains.Annotations;
using TeamSwim;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Prepends a <paramref name="value"/> with a specified <paramref name="prependText"/> string.
        /// </summary>
        /// <param name="value">String that will have <paramref name="prependText"/> prepended to the beginning of it.</param>
        /// <param name="prependText">Text that will be prepended to the beginning of <paramref name="value"/>.</param>
        /// <param name="onlyPrependIfNotStartsWith">
        /// <para>
        ///     Setting this to <see langword="true"/> will <c>only</c> return the affected string if it doesn't 
        ///     already start with the specified <paramref name="prependText"/>. Otherwise, no checks are performed.
        /// </para>
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is not <see langword="null" />, but <paramref name="prependText"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static string Prepend(
            [NotNull] this string value,
            [NotNull] string prependText,
            bool onlyPrependIfNotStartsWith = false)
        {
            if (value == null) throw Exceptions.NullRef();
            if (prependText == null) throw Exceptions.ArgumentNull(nameof(prependText));

            if (onlyPrependIfNotStartsWith && value.StartsWith(prependText)) return value;
            return String.Concat(prependText, value);
        }

        /// <summary>
        ///     Prepends a <paramref name="value"/> with a specified <paramref name="prependChar"/> character.
        /// </summary>
        /// <param name="value">String that will have <paramref name="prependChar"/> prepended to the beginning of it.</param>
        /// <param name="prependChar">Character that will be prepended to the beginning of <paramref name="value"/>.</param>
        /// <param name="onlyPrependIfNotStartsWith">
        /// <para>
        ///     Setting this to <see langword="true"/> will <c>only</c> return the affected string if it doesn't 
        ///     already start with the specified <paramref name="prependChar"/>. Otherwise, no checks are performed.
        /// </para>
        /// </param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static string Prepend(
            [NotNull] this string value,
            char prependChar,
            bool onlyPrependIfNotStartsWith = false) =>
            Prepend(value, prependChar.ToString(), onlyPrependIfNotStartsWith);
    }
}