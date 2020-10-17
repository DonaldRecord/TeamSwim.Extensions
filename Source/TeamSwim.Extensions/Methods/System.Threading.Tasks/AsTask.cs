using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Threading.Tasks
{
    /// <summary>
    ///     Extension methods in System.Threading.Tasks namespace.
    /// </summary>
    public static class TasksExt
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
    }
}
