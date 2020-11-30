using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Flatten a list of hierarchical objects with a 1-to-1 nested structure.
        /// </summary>
        /// <typeparam name="T">Hierarchical object type.</typeparam>
        /// <param name="parents">List of parent elements.</param>
        /// <param name="getChild">Function to receive child object.</param>
        /// <returns>Flattened list of objects.</returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<T> Flatten<T>(
            [NotNull, InstantHandle] this IEnumerable<T> parents,
            [NotNull, InstantHandle] Func<T, T> getChild)
        {
            if (parents == null) throw Exceptions.ArgumentNull(nameof(parents));
            if (getChild == null) throw Exceptions.ArgumentNull(nameof(getChild));

            foreach (var parent in parents)
            {
                var flatParent = FlattenImpl(parent, getChild);
                foreach (var child in flatParent)
                    yield return child;
            }
        }

        //IMPLEMENTATION
        private static IEnumerable<T> FlattenImpl<T>(this T parent, Func<T, T> getChild)
        {
            if (parent != null)
            {
                yield return parent; // return the parent.

                var child = getChild.Invoke(parent);
                if (child != null)
                {
                    var children = FlattenImpl(child, getChild);

                    foreach (var subChild in children)
                        yield return subChild;
                }
            }
        }
    }
}