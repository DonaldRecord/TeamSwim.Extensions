using JetBrains.Annotations;
// ReSharper disable CoVariantArrayConversion

namespace System
{
    partial class ActionExt
    {
        /// <summary>
        ///     Merge the method bodies of several <see cref="Action{T1, T2}"/> delegates.
        /// </summary>
        /// <typeparam name="T1">First type parameter of the delegate.</typeparam>
        /// <typeparam name="T2">Second type parameter of the delegate.</typeparam>
        /// <param name="value">The First <see cref="Action{T1, T2}"/> delegate.</param>
        /// <param name="newDelegates">Array of subsequent delegates to merge.</param>
        /// <returns>A single <see cref="Action{T1, T2}"/> delegates with a method body merged from all input delegates.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Action<T1, T2> Merge<T1, T2>(
            [NotNull] this Action<T1, T2> value,
            [NotNull, ItemCanBeNull] params Action<T1, T2>[] newDelegates)
        {
            var news = Delegate.Combine(newDelegates);
            var ret = Delegate.Combine(value, news);
            return (Action<T1, T2>) ret;
        }
    }
}
