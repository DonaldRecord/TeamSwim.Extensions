#if NET5_0 || NET6_0
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace System.Threading
{
    partial class CancellationTokenExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Verifies that cancellation was not requested and returns <see cref="ValueTask.CompletedTask"/> if it is not.
        ///     If the cancellation token requested cancellation, an <see cref="OperationCanceledException"/> will be thrown.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to verify before continuing.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static ValueTask AsCompletedValueTask(this CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ValueTask.CompletedTask;
        }

        /// <summary>
        ///     (Opinionated)
        ///     Verifies that cancellation was not requested and returns ValueTask.FromResult&lt;T&gt; if it is not.
        ///     If the cancellation token requested cancellation, an <see cref="OperationCanceledException"/> will be thrown.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to verify before continuing.</param>
        /// <param name="result">Result to return in task.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static ValueTask<T> AsCompletedValueTask<T>(this CancellationToken cancellationToken, T result)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ValueTask.FromResult(result);
        }
    }
}
#endif