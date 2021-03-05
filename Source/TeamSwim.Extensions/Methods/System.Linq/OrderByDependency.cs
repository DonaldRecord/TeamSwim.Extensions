using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Iterator to order elements based on their dependency to other elements in the current list.
        /// <para>
        ///     Elements that claim reference to itself will be returned, but the dependency itself will be dis-regarded.
        ///     Without any dependencies affecting order, the returned list will maintain the same order.
        /// </para>
        /// <para>
        ///     Circular dependencies will throw an <see cref="InvalidOperationException"/>.
        /// </para>
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <typeparam name="TKey">Type of key comparison.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="referenceKey">Function to get an element's key, as it would be referenced by other elements.</param>
        /// <param name="dependents">Function to get al element's dependencies.</param>
        /// <param name="keyComparer">Equality comparer to use for key comparison.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<T> OrderByDependency<T, TKey>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [NotNull] Func<T, TKey> referenceKey,
            [NotNull] Func<T, IEnumerable<TKey>> dependents,
            IEqualityComparer<TKey> keyComparer = null)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (referenceKey == null) throw Exceptions.ArgumentNull(nameof(referenceKey));
            if (dependents == null) throw Exceptions.ArgumentNull(nameof(dependents));

            var clone = new List<T>(source);
            if (!clone.Any()) 
                yield break;

            var dependencyGraph = new Dictionary<T, ICollection<TKey>>();
            keyComparer ??= EqualityComparer<TKey>.Default;

            TKey GetReferenceKey(T instance)
            {
                if (instance == null)
                    throw new ArgumentException("Source contains null elements.", nameof(source));
                return referenceKey.Invoke(instance);
            }

            do
            {
                var elem = clone[0];
                if (!dependencyGraph.ContainsKey(elem))
                    dependencyGraph[elem] = dependents.Invoke(elem).ToList();

                var dependsOn = dependencyGraph[elem];
                if (!dependsOn.Any())
                {
                    yield return elem;
                    clone.RemoveAt(0);
                }
                else
                {
                    var stillExisting = clone.Skip(1).Where(c => dependsOn.Contains(GetReferenceKey(c), keyComparer)).ToList();
                    if (stillExisting.Any())
                    {
                        // TODO: Sub-optimal
                        var circular = false;
                        foreach (var lookup in stillExisting)
                        {
                            // if it not yet put in the dependency graph, put it at the back of the list
                            if (!dependencyGraph.ContainsKey(lookup))
                                break;

                            var key = GetReferenceKey(elem);
                            var matches = dependencyGraph.Where(g => g.Value.Contains(key, keyComparer)).ToList();
                            if (matches.Any())
                            {
                                foreach (var match in matches)
                                {
                                    var we = dependencyGraph[elem];
                                    var matchKey = referenceKey.Invoke(match.Key);
                                    if (we.Contains(matchKey, keyComparer))
                                        circular = true;
                                }
                            }
                        }

                        if (circular)
                            throw new InvalidOperationException("Circular order dependencies detected.");

                        clone.Add(elem);
                        clone.RemoveAt(0);
                    }
                    else
                    {
                        yield return clone[0];
                        clone.RemoveAt(0);
                    }
                }

            } while (clone.Any());
        }
    }
}
