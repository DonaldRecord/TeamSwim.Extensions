using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Split a sequence into smaller sequence of a given <paramref name="partitionSize"/>.
        /// </summary>
        /// <param name="source">Sequence to partition.</param>
        /// <param name="partitionSize">Maximum size of each partition.</param>
        /// <typeparam name="T">Element type of sequence.</typeparam>
        /// <returns>One or many sequences of <typeparamref name="T"/>. The last sequence may not be of given <paramref name="partitionSize"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="partitionSize"/> is not a positive integer.</exception>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        public static IEnumerable<IList<T>> Partition<T>(
            this IEnumerable<T> source, 
            int partitionSize)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (partitionSize <= 0) throw new ArgumentOutOfRangeException(nameof(partitionSize), $"{nameof(partitionSize)} must be greater than zero.");
            
            var partition = new List<T>();
            var count = 0;

            foreach (var item in source)
            {
                partition ??= new List<T>(partitionSize);
                partition.Add(item);
                count++;

                if (count != partitionSize)
                    continue;

                yield return partition;

                partition = null;
                count = 0;
            }

            if (!partition.IsNullOrEmpty())
            {
                yield return partition;
            }
        }
    }
}
