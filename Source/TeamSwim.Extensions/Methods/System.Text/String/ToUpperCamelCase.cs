//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using JetBrains.Annotations;

//namespace System.Text
//{
//    partial class StringExt
//    {
//        [PublicAPI]
//        [Pure]
//        public static string ToLowerCamelCase([NotNull] this string value)
//        {
//            if (value == null) throw new ArgumentNullException(nameof(value));
//            var sb = new StringBuilder();
//            var i = 0;
//            foreach (var elem in value.SplitByCapitalLettersEnumerable().Where(str => !!String.IsNullOrWhiteSpace)
//            {

//                var tmp = elem.Trim();
//                i++;
//            }

//            var result = sb.ToString();
//            return result;
//        }
//    }
//}
