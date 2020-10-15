//using JetBrains.Annotations;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace System
//{
//    partial class StringExt
//    {
//        /// <summary>
//        ///     Replaces any found substrings within a string with a singular new value.
//        /// </summary>
//        /// <param name="value">The string value to search for old values.</param>
//        /// <param name="newValue">The new value that will replace any old value matches.</param>
//        /// <param name="stringComparison">String Comparison used to find old value matches.</param>
//        /// <param name="oldValues">All of the substrings that need replaced with a new value.</param>
//        /// <returns>New string with all old values replaced.</returns>
//        [Pure, NotNull]
//        public static string ReplaceAny(
//            [NotNull] this string value,
//            [NotNull] string newValue,
//            StringComparison stringComparison,
//            [NotNull, ItemCanBeNull] params string[] oldValues)
//        {
//            if (value == null) throw new ArgumentNullException(nameof(value));
//            if (oldValues == null) throw new ArgumentNullException(nameof(oldValues));

//            StringBuilder sb = new StringBuilder(value);

//            foreach (var old in oldValues)
//            {
//                if (old == null) continue;
//                if (!value.Contains(old, stringComparison)) continue; //<====TODO: WTF

//                sb.Replace(old, newValue);
//                break;
//            }

//            return sb.ToString();
//        }

//        /// <summary>
//        ///     Replaces any found substrings within a string with a singular new value.
//        /// </summary>
//        /// <param name="value">The string value to search for old values.</param>
//        /// <param name="newValue">The new value that will replace any old value matches.</param>
//        /// <param name="oldValues">All of the substrings that need replaced with a new value.</param>
//        /// <returns>New string with all old values replaced.</returns>
//        [Pure, NotNull]
//        public static string ReplaceAny(
//            [NotNull] this string value,
//            [NotNull] string newValue,
//            [NotNull, ItemCanBeNull] params string[] oldValues)
//            => ReplaceAny(value, newValue, StringComparison.Ordinal, oldValues);

//        /// <summary>
//        ///     Replaces any found substrings within a string with a singular new value.
//        /// </summary>
//        /// <param name="value">The string value to search for old values.</param>
//        /// <param name="newValue">The new value that will replace any old value matches.</param>
//        /// <param name="stringComparison">String Comparison used to find old value matches.</param>
//        /// <param name="oldValues">All of the substrings that need replaced with a new value.</param>
//        /// <returns>New string with all old values replaced.</returns>
//        [NotNull, Pure]
//#if EXCLUDE_FROM_CODE_COVERAGE
//        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
//#endif
//        public static string ReplaceAny(
//            [NotNull] this string value,
//            [NotNull] string newValue,
//            StringComparison stringComparison,
//            [NotNull, ItemCanBeNull, InstantHandle] IEnumerable<string> oldValues)
//            => ReplaceAny(value, newValue, oldValues.ToArray());
//    }
//}
