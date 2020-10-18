using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class Utility
    {
        public static string RandomString(
            int minLength = 1,
            int maxLength = 4,
            string exclusion = null)
        {
            var chars =
                Enumerable.Range(97, 26).Select(i => (char)i)
                    .Union(Enumerable.Range(65, 26).Select(i => (char)i))
                    .Take(Enumerable.Range(minLength, maxLength - minLength + 1)
                        .OrderBy(_ => Guid.NewGuid())
                        .First());

            var result = new string(chars.ToArray());

            if (exclusion != null)
            {
                if (exclusion.Equals(result, StringComparison.OrdinalIgnoreCase))
                    return RandomString(minLength, maxLength, exclusion); // just try again
            }

            return result;
        }

        public static DateTime RandomDateTime() =>
            new DateTime(1940, 1, 1)
                .AddSeconds(Enumerable.Range(214_748_364, 10_000)
                    .OrderBy(_ => Guid.NewGuid()).First());

        public static int RandomInteger() => Enumerable.Range(1, 200).OrderBy(_ => Guid.NewGuid()).First();
    }
}
