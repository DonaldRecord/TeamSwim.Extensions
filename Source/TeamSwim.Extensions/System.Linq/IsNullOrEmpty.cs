using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Determines if the collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <returns><see langword="true"/> if the collection is <see langword="null"/> or empty. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure, ContractAnnotation("source:notnull=>true;source:null=>false")]
        public static bool IsNullOrEmpty<T>([CanBeNull, InstantHandle] this IEnumerable<T> source)
        {
            if (source == null) 
                return true;
            else
                return !source.Any();
        }
    }
}