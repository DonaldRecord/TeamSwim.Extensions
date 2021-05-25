using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System
{
    partial class BooleanExt
    {
        /// <summary>
        ///     Short-hand switch statement for returning a specified value
        ///     when the <paramref name="value"/> is <see langword="true"/>
        ///     and a different value when the <paramref name="value"/> is <see langword="false"/>.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="value"><see langword="bool"/> value.</param>
        /// <param name="whenTrue">Return value when <paramref name="value"/> is <see langword="true"/>.</param>
        /// <param name="whenFalse">Return value when <paramref name="value"/> is <see langword="false"/>.</param>
        /// <returns><paramref name="whenTrue"/> when <paramref name="value"/> is <see langword="true"/>. Otherwise, <paramref name="whenFalse"/>.</returns>
        [PublicAPI]
        [Pure]
        public static T Switch<T>(this bool value, T whenTrue, T whenFalse) => value ? whenTrue : whenFalse;
    }
}