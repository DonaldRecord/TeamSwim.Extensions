using JetBrains.Annotations;

namespace System
{
    partial class CloneableExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Clone an object and return the cloned value after casting it to the
        ///     origin type of the original <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static T CloneAndCast<T>([NotNull] this T value) where T : ICloneable
            => (T)value.Clone();
    }
}
