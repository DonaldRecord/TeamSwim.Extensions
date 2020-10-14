using JetBrains.Annotations;
// ReSharper disable CoVariantArrayConversion

namespace System
{
    public static partial class ActionExt
    {
        /// <summary>
        ///     Merge together several <see cref="Action"/> delegates.
        /// </summary>
        /// <param name="value">First <see cref="Action"/> value being merged.</param>
        /// <param name="newActions">Parameter array of <see cref="Action"/> being merged together.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Action Merge(
            [NotNull] this Action value,
            [NotNull, ItemCanBeNull] params Action[] newActions)
        {
            var news = Delegate.Combine(newActions);
            var ret = Delegate.Combine(value, news);
            return (Action) ret;
        }
    }
}
