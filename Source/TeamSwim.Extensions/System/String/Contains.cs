//using JetBrains.Annotations;

//namespace System
//{
//    public static partial class StringExt
//    {
//        /// <summary>
//        ///     Returns a value indicating whether a specified substring occurs within this string 
//        ///     with the specified StringComparison.
//        /// </summary>
//        /// <returns>true if the <paramref name="value" /> parameter occurs within this string, or if <paramref name="value" /> is the empty string (""); otherwise, false.</returns>
//        /// <param name="string">The string being seeked.</param>
//        /// <param name="value">The string to seek.</param>
//        /// <param name="comparison">The <see cref="StringComparison"/> type being used to seek.</param>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is null. </exception>
        
//        public static bool Contains([NotNull] this string @string, [NotNull] string value, StringComparison comparison)
//            => @string.IndexOf(value, comparison) >= 0;
//    }
//}