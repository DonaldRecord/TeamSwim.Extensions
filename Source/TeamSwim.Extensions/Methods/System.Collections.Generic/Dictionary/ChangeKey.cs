using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Collections.Generic
{
    partial class DictionaryExt
    {
        /// <summary>
        ///     Change the specified key in a Dictionary <paramref name="value"/>, and returns a value
        ///     as to whether or not the value was actually identified/changed.
        /// </summary>
        /// <typeparam name="TKey">Key type.</typeparam>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="value">Dictionary instance to change key for.</param>
        /// <param name="currentKey">Current key in dictionary.</param>
        /// <param name="newKey">New key to transition into.</param>
        [PublicAPI]
        public static bool ChangeKey<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> value,
            TKey currentKey,
            TKey newKey)
        {
            if (value == null)
                throw Exceptions.ArgumentNull(nameof(value));

            if (value.ContainsKey(currentKey))
            {
                value[newKey] = value[currentKey];
                value.Remove(currentKey);
                return true;
            }

            return false;
        }
    }
}
