using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Mutate objects in a collection.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="mutation">Mutation method.</param>
        /// <param name="predicate">Filters objects that will be mutated.</param>
        /// <returns>Mutated collection.</returns>
        [MustUseReturnValue, PublicAPI, LinqTunnel]
        public static IEnumerable<T> Mutate<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Action<T> mutation,
            [CanBeNull, InstantHandle] Func<T, bool> predicate = null) where T : class
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (mutation == null) throw new ArgumentNullException(nameof(mutation));

            foreach (var element in source)
            {
                if (predicate == null || predicate.Invoke(element))
                {
                    mutation.Invoke(element);
                    yield return element;
                }
            }
        }

        /// <summary>
        ///     Mutate objects in a collection.
        ///     Provides access to the [zero-based] ordinal of the element within the collection.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="mutation">Mutation method.</param>
        /// <param name="predicate">Filters objects that will be mutated.</param>
        /// <returns>Mutated collection.</returns>
        [MustUseReturnValue, PublicAPI, LinqTunnel]
        public static IEnumerable<T> Mutate<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Action<T, int> mutation,
            [NotNull, InstantHandle] Func<T, int, bool> predicate = null) where T : class
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (mutation == null) throw new ArgumentNullException(nameof(mutation));

            var i = 0;
            foreach (var element in source)
            {
                if (predicate == null || predicate.Invoke(element, i))
                {
                    mutation.Invoke(element, i);
                }
                
                yield return element;
                i++;
            }
        }
    }
}