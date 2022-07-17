using JetBrains.Annotations;

namespace System
{
    partial class FuncExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="appendedFunc"></param>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static Func<TArg1, TResult> Append<TArg1, TResult>(
            this Func<TArg1, TResult> value,
            Func<TResult, TResult> appendedFunc) =>
            arg1 => appendedFunc.Invoke(value.Invoke(arg1));
    }
}
