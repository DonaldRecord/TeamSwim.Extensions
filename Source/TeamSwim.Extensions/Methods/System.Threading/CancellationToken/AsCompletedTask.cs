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
        ///     Verifies that cancellation was not requested and returns <see cref="Task.CompletedTask"/> if it is not.
        ///     If the cancellation token requested cancellation, an <see cref="OperationCanceledException"/> will be thrown.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to verify before continuing.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Task AsCompletedTask(this CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.CompletedTask;
        }
    }
}
