//using JetBrains.Annotations;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;

//namespace System
//{
//    /// <summary>
//    ///     Extension method class for <see cref="string"/>.
//    /// </summary>
//    partial class StringExt
//    {
//        /// <summary>
//        ///     Replaces all found substrings within a string with a singular new value.
//        /// </summary>
//        /// <param name="value">The string value to search for old values.</param>
//        /// <param name="newValue">The new value that will replace any old value matches.</param>
//        /// <param name="stringComparison">String Comparison used to find old value matches.</param>
//        /// <param name="oldValues">All of the substrings that need replaced with a new value.</param>
//        /// <returns>New string with all old values replaced.</returns>
//        [Pure, NotNull, PublicAPI]
//        public static string ReplaceAll(
//            [NotNull] this string value,
//            [CanBeNull, NoEnumeration] string newValue,
//            StringComparison stringComparison,
//            [NotNull, ItemCanBeNull, NoEnumeration] params string[] oldValues)
//        {
//            if (value == null) throw new ArgumentNullException(nameof(value));
//            if (oldValues == null) throw new ArgumentNullException(nameof(oldValues));

//            StringBuilder sb = new StringBuilder(value);

//            foreach (var old in oldValues)
//            {
//                if (old == null) continue;
//                if (!value.Contains(old, stringComparison)) continue; //TODO: <------ WTF

//                sb.Replace(old, newValue ?? String.Empty);
//                //break; <= ONLY DIFFERENCE BETWEEN .ReplaceAny() and .ReplaceAll().
//            }

//            return sb.ToString();
//        }

//        /// <summary>
//        ///     Replaces all found substrings within a string with a singular new value.
//        /// </summary>
//        /// <param name="value">The string value to search for old values.</param>
//        /// <param name="newValue">The new value that will replace any old value matches.</param>
//        /// <param name="stringComparison">String Comparison used to find old value matches.</param>
//        /// <param name="oldValues">All of the substrings that need replaced with a new value.</param>
//        /// <returns>New string with all old values replaced.</returns>
//        [Pure, NotNull, ExcludeFromCodeCoverage]
//        public static string ReplaceAll(
//            [NotNull] this string value,
//            [CanBeNull, NoEnumeration] string newValue,
//            StringComparison stringComparison,
//            [NotNull, InstantHandle] IEnumerable<string> oldValues)
//            => ReplaceAll(value, newValue, stringComparison, oldValues.ToArray());
//    }
//}
