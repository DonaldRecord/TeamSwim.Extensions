using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System
{
    partial class ExceptionExt
    {
        /// <summary>
        ///     Returns a flattened list of exceptions from a single parent <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception">Parent exception.</param>
        /// <returns>Flattened list of exceptions from a single parent.</returns>
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<Exception> Expand([NotNull] this Exception exception)
        {
            if (exception == null) throw Exceptions.ArgumentNull(nameof(exception));

            var ex = exception;
            do
            {
                yield return ex;

                if (ex is AggregateException agex)
                {
                    foreach (var inex in agex.InnerExceptions)
                    {
                        var exinex = Expand(inex);
                        foreach (var ex2 in exinex)
                            yield return ex2;
                    }
                }

                ex = ex.InnerException;
            } while (ex != null);
        }
    }
}
