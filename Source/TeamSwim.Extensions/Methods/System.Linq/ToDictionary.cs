using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Creates a new <see cref="Dictionary{TKey, TValue}" /> from an <see cref="IEnumerable{T}"/>
        ///     according to specified key/value selector functions.
        /// </summary>
        /// <typeparam name="T">Element type of source <see cref="IEnumerable{T}"/>.</typeparam>
        /// <typeparam name="TKey">Key type of result <see cref="Dictionary{TKey, TValue}"/>.</typeparam>
        /// <typeparam name="TValue">Value type of result <see cref="Dictionary{TKey, TValue}"/>.</typeparam>
        /// <param name="source">Source sequence to return <see cref="Dictionary{TKey, TValue}"/>.</param>
        /// <param name="keySelector">Key selector function for result <see cref="Dictionary{TKey, TValue}"/>.</param>
        /// <param name="valueSelector">Value selector function for result <see cref="Dictionary{TKey, TValue}"/>.</param>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains values of type <typeparamref name="T"/> selected from the input sequence.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [NotNull, InstantHandle] Func<T, int, TKey> keySelector,
            [NotNull, InstantHandle] Func<T, int, TValue> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (valueSelector == null) throw new ArgumentNullException(nameof(valueSelector));

            var i = 0;
            var result = new Dictionary<TKey, TValue>();
            foreach (var elem in source)
            {
                var key = keySelector.Invoke(elem, i);
                var value = valueSelector.Invoke(elem, i);
                result.Add(key, value);
                i++;
            }

            return result;
        }
    }
}
