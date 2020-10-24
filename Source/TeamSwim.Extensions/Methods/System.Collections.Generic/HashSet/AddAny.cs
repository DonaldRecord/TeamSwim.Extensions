using JetBrains.Annotations;

namespace System.Collections.Generic
{
    partial class HashSetExt
    {
        /// <summary>
        ///     Adds a <paramref name="range"/> of <typeparamref name="T"/> to the <see cref="HashSet{T}"/> 
        ///     and returns a <see cref="bool"/> indicating if any of the elements were added.
        /// </summary>
        /// <typeparam name="T">The element type of the <see cref="HashSet{T}"/>.</typeparam>
        /// <param name="hashSet">The <see cref="HashSet{T}"/> being added to.</param>
        /// <param name="range">The <see cref="IEnumerable{T}"/> range being added to the <see cref="HashSet{T}"/>.</param>
        /// <returns>If any elements are added, returns <see langword="true"/>. Otherwise, <see langword="false"/> </returns>
        [PublicAPI]
        // TODO: Make custom exceptions
        public static bool AddAny<T>(
            [NotNull, NoEnumeration] this HashSet<T> hashSet,
            [NotNull, ItemCanBeNull, InstantHandle] IEnumerable<T> range)
        {
            if (hashSet == null) throw new NullReferenceException();
            if (range == null) throw new ArgumentNullException(nameof(range));

            var retVal = false;

            foreach (var value in range)
            {
                var has = hashSet.Add(value);

                if (!retVal && has)
                    retVal = true;
            }

            return retVal;
        }
    }
}