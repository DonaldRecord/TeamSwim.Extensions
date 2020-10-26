using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

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
        [PublicAPI]
        [MustUseReturnValue, NotNull, ItemCanBeNull, LinqTunnel]
        public static IEnumerable<T> Pipe<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Action<T> mutation,
            [CanBeNull, InstantHandle] Func<T, bool> predicate = null) where T : class
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (mutation == null) throw Exceptions.ArgumentNull(nameof(mutation));

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
        [PublicAPI]
        [MustUseReturnValue, LinqTunnel]
        public static IEnumerable<T> Pipe<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Action<T, int> mutation,
            [NotNull, InstantHandle] Func<T, int, bool> predicate = null) where T : class
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (mutation == null) throw Exceptions.ArgumentNull(nameof(mutation));

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