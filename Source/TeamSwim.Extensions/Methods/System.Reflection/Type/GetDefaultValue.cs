using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    partial class TypeExt
    {
        /// <summary>
        ///     Non-generic way of getting the <see langword="default"/> value for a given <paramref name="type"/>.
        ///     For classes, this method will return <see langword="null"/>.
        ///     For structs, this method will return the <see langword="default"/> value.
        /// </summary>
        /// <param name="type">The type to get default value for.</param>
        /// <returns>The default value of the specified type</returns>
        [PublicAPI]
        [Pure, CanBeNull]
        public static object GetDefaultValue([NotNull] this Type type)
        {
            if (type == null) throw Exceptions.ArgumentNull(nameof(type));

            var result = typeof(TypeExt)
                .GetMethod(nameof(GetDefaultValueImpl), BindingFlags.Static | BindingFlags.NonPublic)
                .MakeGenericMethod(type)
                .Invoke(null, Array.Empty<object>());

            return result;
        }

        private static T GetDefaultValueImpl<T>() => default;
    }
}
