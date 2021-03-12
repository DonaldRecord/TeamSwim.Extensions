using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Execute <paramref name="routine"/> against each element in a sequence.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="routine">Routine function.</param>
        /// <param name="predicate">Filters objects that will be ran against.</param>
        /// <returns>The source sequence.</returns>
        [PublicAPI]
        [MustUseReturnValue, NotNull, ItemCanBeNull, LinqTunnel]
        public static IEnumerable<T> Tap<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Action<T> routine,
            [CanBeNull, InstantHandle] Func<T, bool> predicate = null) where T : class
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (routine == null) throw Exceptions.ArgumentNull(nameof(routine));

            foreach (var element in source)
            {
                if (predicate == null || predicate.Invoke(element))
                {
                    routine.Invoke(element);
                    yield return element;
                }
            }
        }

        /// <summary>
        ///     Execute <paramref name="routine"/> against each element in a sequence.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="routine">Routine function.</param>
        /// <param name="predicate">Filters objects that will be ran against.</param>
        /// <returns>The source sequence.</returns>
        [PublicAPI]
        [MustUseReturnValue, LinqTunnel]
        public static IEnumerable<T> Tap<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Action<T, int> routine,
            [CanBeNull, InstantHandle] Func<T, int, bool> predicate = null) where T : class
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (routine == null) throw Exceptions.ArgumentNull(nameof(routine));

            var i = 0;
            foreach (var element in source)
            {
                if (predicate == null || predicate.Invoke(element, i))
                {
                    routine.Invoke(element, i);
                }
                
                yield return element;
                i++;
            }
        }
    }
}