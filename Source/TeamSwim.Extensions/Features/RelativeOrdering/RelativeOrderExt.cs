using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using TeamSwim.Features.RelativeOrdering;

namespace System.Linq
{
    /// <summary>
    ///     Extension method class for using relative ordering.
    /// </summary>
    public static class RelativeOrderExt
    {
        // TODO: Optimize
        /// <summary>
        ///     Use relative ordering on the <paramref name="source"/> sequence.
        ///     The <paramref name="source"/> sequence will be enumerated during this process.
        /// </summary>
        /// <typeparam name="T">Element type of sequence and specifies the relative ordering configuration to use.</typeparam>
        /// <param name="source">Source sequence to order.</param>
        /// <returns>Re-ordered sequence.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static IEnumerable<T> WithRelativeOrdering<T>([NotNull, InstantHandle] this IEnumerable<T> source)
        {
            RelativeOrderInstruction GetInstruction(T t)
            {
                if (t is not IRelativeOrderEnabled<T> ro)
                    return new RelativeOrderInstruction(t.GetType(), typeof(T));

                var b = new RelativeOrderInstructionBuilder<T>(t.GetType());
                ro.Setup?.Invoke(b);
                var result = b.Build();
                return result;
            }

            var list = source.ToList();

            if (list.Count == 0)
                yield break;

            if (list.Count == 1)
            {
                yield return list.First();
                yield break;
            }

            var comparer = new RelativeOrderComparer();
            var matrix = new List<RelativeOrder<T>>();

            foreach (var elem in list)
            {
                var record = new RelativeOrder<T>(elem, GetInstruction(elem));

                foreach (var elem2 in list)
                {
                    if (ReferenceEquals(elem, elem2))
                        continue;

                    var i = comparer.Compare(record.Current.Instruction, GetInstruction(elem2));
                    var compareResult = new RelativeOrderCompareResult<T>(elem2, GetInstruction(elem), i);
                    record.Comparisons.Add(compareResult);
                }

                matrix.Add(record);
            }

            while (matrix.Count > 1)
            {
                for (var i = 0; i < matrix.Count; i++)
                {
                    var current = matrix[i];

                    var canGo = current.Comparisons.All(c => c.CompareResult is RelativeOrderComparer.Inconclusive or RelativeOrderComparer.Before);
                    if (canGo)
                    {
                        yield return current.Current.Instance;
                        matrix.RemoveAt(i);
                        foreach (var m in matrix)
                        {
                            m.Comparisons.RemoveAll(c => ReferenceEquals(c.Instance, current.Current.Instance));
                        }
                        break;
                    }
                }
            }

            if (matrix.Count == 1)
                yield return matrix.Single().Current.Instance;
        }

        [DebuggerDisplay("{Current.Instance.GetType()}")]
        class RelativeOrder<T>
        {
            public RelativeOrder(T instance, RelativeOrderInstruction instruction)
            {
                Current = new RelativeOrderResult<T>(instance, instruction);
            }

            public RelativeOrderResult<T> Current { get; }
            public List<RelativeOrderCompareResult<T>> Comparisons { get; } = new List<RelativeOrderCompareResult<T>>();
        }

        [DebuggerDisplay("{Instance.GetType()}")]
        class RelativeOrderResult<T>
        {
            public RelativeOrderResult(T instance, RelativeOrderInstruction instruction)
            {
                Instance = instance;
                Instruction = instruction;
            }

            public T Instance { get; }
            public RelativeOrderInstruction Instruction { get; }
        }

        [DebuggerDisplay("{CompareResult} - {Instance.GetType()}")]
        class RelativeOrderCompareResult<T> : RelativeOrderResult<T>
        {
            public int CompareResult { get; }

            public RelativeOrderCompareResult(
                T instance,
                RelativeOrderInstruction instruction,
                int compareResult) : base(instance, instruction)
            {
                CompareResult = compareResult;
            }
        }
    }
}
