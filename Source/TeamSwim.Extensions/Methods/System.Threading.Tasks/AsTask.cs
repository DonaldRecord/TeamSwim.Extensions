using JetBrains.Annotations;

namespace System.Threading.Tasks
{
    partial class TasksExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Extension method invocation of <see cref="Task.FromResult{TResult}(TResult)" />.
        /// </summary>
        /// <typeparam name="T">Type of </typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Task<T> AsTask<T>([CanBeNull] this T value) => Task.FromResult(value);

        /// <summary>
        ///     (Opinionated)
        ///     Extension method invocation of <see cref="Task.FromResult{TResult}(TResult)" />
        ///     that will assert passed <paramref name="cancellationToken"/>.
        /// </summary>
        /// <typeparam name="T">Type of </typeparam>
        /// <param name="value"></param>
        /// <param name="cancellationToken">Cancellation token to check for cancellation.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Task<T> AsTask<T>([CanBeNull] this T value, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(value);
        }
    }
}
