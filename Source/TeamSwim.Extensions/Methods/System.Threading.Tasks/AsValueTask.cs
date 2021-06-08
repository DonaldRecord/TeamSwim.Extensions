//using System;
//using System.Collections.Generic;
//using JetBrains.Annotations;

//namespace System.Threading.Tasks
//{
//    partial class TasksExt
//    {
//        /// <summary>
//        ///     (Opinionated)
//        ///     Extension method invocation of creating a <see cref="ValueTask"/> instance.
//        /// </summary>
//        /// <typeparam name="T">Type of value.</typeparam>
//        /// <param name="value">Value to crteate <see cref="ValueTask"/> instance from.</param>
//        /// <returns>Instance of <see cref="ValueTask"/> containing the initial <paramref name="value"/>.</returns>
//        [PublicAPI]
//        [Pure]
//        public static ValueTask<T> AsValueTask<T>(this T value) => new ValueTask<T>(value);
//    }
//}
