﻿using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns the single element of a sequence that satisfies one of the predicates, or default of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="predicates">Predicates to evaluate for returning an element.</param>
        /// <returns>The single element to satisfy one of the predicates, or default of <typeparamref name="T"/>.</returns>
        [PublicAPI]
        [Pure]
        public static T SingleOrDefaultCoalesce<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [NotNull, ItemNotNull, InstantHandle] params Func<T, bool>[] predicates)
        {
            var matches = new List<Tuple<int, T>>();

            foreach (var elem in source)
            {
                var i = 0;
                foreach (var predicate in predicates)
                {
                    if (predicate == null)
                        throw new ArgumentException("One of the passed predicates was null.").WithSource();

                    var match = predicate.Invoke(elem);
                    if (match)
                    {
                        if (i == 0)
                            return elem;
                        else
                            matches.Add(new Tuple<int, T>(i, elem));
                    }

                    i++;
                }
            }

            if (matches.Any())
                return matches.OrderBy(m => m.Item1).Single().Item2;
            else
                return default;
        }
    }
}