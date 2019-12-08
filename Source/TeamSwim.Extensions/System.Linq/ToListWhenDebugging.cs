using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Will create a list of elements only when the debugger is attached.
        ///     This is useful for large lists so that they are not fully loaded into memory in production environments,
        ///     but Visual Studio debugger displays can be more helpful while debugging in a developer environment.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <returns><paramref name="source"/> un-affected, if the debugger is not attached. Otherwise, a collection (still passed as <see cref="IEnumerable{T}"/>.</returns>
        [Pure, NotNull, PublicAPI] //[LinqTunnel]?
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