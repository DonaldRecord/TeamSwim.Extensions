﻿using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using TeamSwim;
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
        /// <para>
        ///     This method will allow <see langword="null"/> sequences to pass through without error.
        /// </para>
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <returns><paramref name="source"/> un-affected, if the debugger is not attached. Otherwise, a collection (still passed as <see cref="IEnumerable{T}"/>.</returns>
        [PublicAPI]
        [Pure, LinqTunnel]
        [ExcludeFromCodeCoverage] // Can't reach 100% in RELEASE config, but this code is trusted and the alternatives are tested.
        [ContractAnnotation("source:null=>null;source:notnull=>notnull")]
        public static IEnumerable<T> ToListWhenDebugging<T>([CanBeNull] this IEnumerable<T> source)
        {
            if (source == null)
                return source;

            if (Debugger.IsAttached)
                return source.ToList();
            else
                return source;
        }
    }
}