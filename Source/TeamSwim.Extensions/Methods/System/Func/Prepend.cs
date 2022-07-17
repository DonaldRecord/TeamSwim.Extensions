using JetBrains.Annotations;

namespace System
{
    partial class FuncExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prependedFunc"></param>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static Func<TArg1, TResult> Prepend<TArg1, TResult>(
            this Func<TArg1, TResult> value,
            Func<TArg1, TArg1> prependedFunc) =>
            arg1 => value.Invoke(prependedFunc.Invoke(arg1));
    }
}