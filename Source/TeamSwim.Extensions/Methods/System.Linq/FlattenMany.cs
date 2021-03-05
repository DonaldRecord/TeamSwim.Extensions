using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Flatten a list of hierarchical objects with a one-to-many nested structure.
        /// </summary>
        /// <typeparam name="T">Hierarchical object type.</typeparam>
        /// <param name="parents">List of parent elements.</param>
        /// <param name="getChildren">Function to receive child object.</param>
        /// <returns>Flattened list of objects.</returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<T> FlattenMany<T>(
            [NotNull, InstantHandle] this IEnumerable<T> parents,
            [NotNull, InstantHandle] Func<T, IEnumerable<T>> getChildren)
        {
            if (parents == null) throw Exceptions.ArgumentNull(nameof(parents));
            if (getChildren == null) throw Exceptions.ArgumentNull(nameof(getChildren));

            foreach (var parent in parents)
            {
                var flatParent = FlattenManyImpl(parent, getChildren);
                foreach (var children in flatParent)
                    yield return children;
            }
        }

        //IMPLEMENTATION
        private static IEnumerable<T> FlattenManyImpl<T>(this T parent, Func<T, IEnumerable<T>> getChildren)
        {
            if (parent == null) 
                yield break;

            yield return parent; // return the parent.

            var children = getChildren.Invoke(parent);
            if (children != null)
            {
                foreach (var child in children)
                {
                    var results = FlattenManyImpl(child, getChildren);
                    foreach (var result in results)
                        yield return result;
                }
            }
        }
    }
}