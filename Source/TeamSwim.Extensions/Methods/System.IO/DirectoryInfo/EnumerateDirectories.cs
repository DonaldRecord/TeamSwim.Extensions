using System;
using System.Collections.Generic;
using System.Linq;
using TeamSwim;
using JetBrains.Annotations;

namespace System.IO
{
    partial class DirectoryInfoExt
    {
        /// <summary>
        ///     Returns an enumerable collection of directory information that passes
        ///     the passed predicate and the search pattern using the specified search option.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="predicate"></param>
        /// <param name="searchPattern">The search string to match against the names of directories.  This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.</param>
        /// <returns>An enumerable collection of directories that matches <paramref name="searchPattern" /> and <paramref name="searchOption" />.</returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel, ItemNotNull]
        [Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static IEnumerable<DirectoryInfo> EnumerateDirectories(
            [NotNull] this DirectoryInfo directory,
            [NotNull, InstantHandle] Func<DirectoryInfo, bool> predicate,
            SearchOption searchOption = SearchOption.AllDirectories,
            string searchPattern = "*")
        {
            if (directory == null) throw Exceptions.ArgumentNull(nameof(directory));
            if (predicate == null) throw Exceptions.ArgumentNull(nameof(predicate));

            var result = directory.EnumerateDirectories(searchPattern, searchOption).Where(predicate);
            return result;
        }
    }
}
