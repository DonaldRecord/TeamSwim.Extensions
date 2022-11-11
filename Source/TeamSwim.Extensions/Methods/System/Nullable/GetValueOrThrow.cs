using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System
{
    partial class NullableExt
    {
        /// <summary>
        ///     Get the value from a <see cref="Nullable{T}"/> or throw the specified exception.
        /// </summary>
        /// <typeparam name="T">Type of underlying value.</typeparam>
        /// <param name="value">Specified value.</param>
        /// <param name="ex">Exception to throw if value is <see langword="null"/>.</param>
        [PublicAPI]
        // TODO: Flow/ContractAnnotation attribute
        public static T GetValueOrThrow<T>(
            [CanBeNull] this T? value, 
            [NotNull] Exception ex) where T : struct
        {
            if (value.HasValue)
                return value.Value;
            else
                throw ex;
        }
    }
}
