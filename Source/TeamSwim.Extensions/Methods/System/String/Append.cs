using JetBrains.Annotations;

namespace System
{
    static partial class StringExt
    {
        /// <summary>
        ///     Appends a <paramref name="value"/> with a specified <paramref name="appendText"/> string.
        /// </summary>
        /// <param name="value">String that will have <paramref name="appendText"/> appended to the end of it.</param>
        /// <param name="appendText">Text that will be appended to the end of <paramref name="value"/>.</param>
        /// <param name="onlyAppendIfNotEndsWith">
        /// <para>
        ///     Setting this to <see langword="true"/> will <c>only</c> return the affected string if it doesn't 
        ///     already end with the specified <paramref name="appendText"/>. Otherwise, no checks are performed.
        /// </para>
        /// </param>
        /// <param name="comparisonType">
        ///     The String Comparison Type to use when checking the end of the string.
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is not <see langword="null" />, but <paramref name="appendText"/> is <see langword="null"/>.</exception>
        [Pure, NotNull, PublicAPI]
        public static string Append(
            [NotNull] this string value,
            [NotNull] string appendText,
            bool onlyAppendIfNotEndsWith,
            StringComparison comparisonType)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (appendText == null) throw new ArgumentNullException(nameof(appendText));

            if (onlyAppendIfNotEndsWith && value.EndsWith(appendText, comparisonType)) return value;
            return String.Concat(value, appendText);
        }

        /// <summary>
        ///     (Opinionated)
        ///     Appends a <paramref name="value"/> with a specified <paramref name="appendText"/> string.
        /// </summary>
        /// <param name="value">String that will have <paramref name="appendText"/> appended to the end of it.</param>
        /// <param name="appendText">Text that will be appended to the end of <paramref name="value"/>.</param>
        /// <param name="onlyAppendIfNotEndsWith">
        /// <para>
        ///     Setting this to <see langword="true"/> will <c>only</c> return the affected string if it doesn't 
        ///     already end with the specified <paramref name="appendText"/>. Otherwise, no checks are performed.
        /// </para>
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is not <see langword="null" />, but <paramref name="appendText"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static string Append(
            [NotNull] this string value,
            [NotNull] string appendText,
            bool onlyAppendIfNotEndsWith)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (appendText == null) throw new ArgumentNullException(nameof(appendText));

            if (onlyAppendIfNotEndsWith && value.EndsWith(appendText)) return value;
            return String.Concat(value, appendText);
        }

        /// <summary>
        ///     Appends a <paramref name="value"/> with a specified <paramref name="appendText"/> string.
        /// </summary>
        /// <param name="value">String that will have <paramref name="appendText"/> appended to the end of it.</param>
        /// <param name="appendText">Text that will be appended to the end of <paramref name="value"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is not <see langword="null" />, but <paramref name="appendText"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static string Append(
            [NotNull] this string value,
            [NotNull, NoEnumeration] string appendText) => Append(value, appendText, false);

        /// <summary>
        ///     Appends a <paramref name="value"/> with a specified <paramref name="appendChar"/> character.
        /// </summary>
        /// <param name="value">String that will have <paramref name="appendChar"/> appended to the end of it.</param>
        /// <param name="appendChar">Character that will be appended to the end of <paramref name="value"/>.</param>
        /// <param name="onlyAppendIfNotEndsWith">
        /// <para>
        ///     Setting this to <see langword="true"/> will <c>only</c> return the affected string if it doesn't 
        ///     already end with the specified <paramref name="appendChar"/>. Otherwise, no checks are performed.
        /// </para>
        /// </param>
        /// <param name="comparisonType">
        ///     The String Comparison Type to use when checking the end of the string.
        /// </param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static string Append(
            [NotNull] this string value,
            char appendChar,
            bool onlyAppendIfNotEndsWith,
            StringComparison comparisonType)
            => Append(value, appendChar.ToString(), onlyAppendIfNotEndsWith, comparisonType);

        /// <summary>
        ///     Appends a <paramref name="value"/> with a specified <paramref name="appendChar"/> character.
        /// </summary>
        /// <param name="value">String that will have <paramref name="appendChar"/> appended to the end of it.</param>
        /// <param name="appendChar">Character that will be appended to the end of <paramref name="value"/>.</param>
        /// <param name="onlyAppendIfNotEndsWith">
        /// <para>
        ///     Setting this to <see langword="true"/> will <c>only</c> return the affected string if it doesn't 
        ///     already end with the specified <paramref name="appendChar"/>. Otherwise, no checks are performed.
        /// </para>
        /// </param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static string Append(
            [NotNull] this string value,
            char appendChar,
            bool onlyAppendIfNotEndsWith)
            => Append(value, appendChar.ToString(), onlyAppendIfNotEndsWith);

        /// <summary>
        ///     Appends a <paramref name="value"/> with a specified <paramref name="appendChar"/> character.
        /// </summary>
        /// <param name="value">String that will have <paramref name="appendChar"/> appended to the end of it.</param>
        /// <param name="appendChar">Character that will be appended to the end of <paramref name="value"/>.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static string Append(
            [NotNull] this string value,
            char appendChar) =>
            Append(value, appendChar.ToString(), false);
    }
}
