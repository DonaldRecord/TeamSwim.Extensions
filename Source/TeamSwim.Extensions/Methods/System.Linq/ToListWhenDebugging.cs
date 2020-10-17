using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using ExcludeFromCodeCoverage = System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Will create a list of elements only when the debugger is attached.
        ///     This is useful for large lists so that they are not fully loaded into memory in production environments,
        ///     but Visual Studio debugger displays can be more helpful while debugging in a developer environment.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <returns><paramref name="source"/> un-affected, if the debugger is not attached. Otherwise, a collection (still passed as <see cref="IEnumerable{T}"/>.</returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        [ExcludeFromCodeCoverage] // Can't reach 100% in RELEASE config, but this code is trusted and the alternatives are tested.
        public static IEnumerable<T> ToListWhenDebugging<T>([NotNull] this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (Debugger.IsAttached)
                return source.ToList();
            else
                return source;
        }
    }
}