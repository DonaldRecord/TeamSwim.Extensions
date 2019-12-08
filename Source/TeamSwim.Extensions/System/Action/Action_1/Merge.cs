using JetBrains.Annotations;
// ReSharper disable CoVariantArrayConversion

namespace System
{
    public static partial class ActionExt
    {
        /// <summary>
        ///     Merge together several <see cref="Action{T}"/> delegates.
        /// </summary>
        /// <typeparam name="T"><see cref="Action"/> type.</typeparam>
        /// <param name="value">First <see cref="Action{T}"/> value being merged.</param>
        /// <param name="newActions">Parameter array of <see cref="Action{T}"/> being merged together.</param>
        /// <returns></returns>
        [Pure, NotNull, PublicAPI]
        public static Action<T> Merge<T>(
            [NotNull] this Action<T> value,
            [NotNull, ItemCanBeNull] params Action<T>[] newActions)
        {
            var news = Delegate.Combine(newActions);
            var ret = Delegate.Combine(value, news);
            return (Action<T>) ret;
        }
    }
}
