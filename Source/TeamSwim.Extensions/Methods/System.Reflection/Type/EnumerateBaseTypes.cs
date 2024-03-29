﻿using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    partial class TypeExt
    {
        /// <summary>
        ///     Enumerate all base types of a specified <paramref name="type"/> from most-specific to least-specific
        ///     (<see cref="object"/> will come last).
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [PublicAPI]
        [NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<Type> EnumerateBaseTypes([NotNull] this Type type)
        {
            if (type == null)
                throw Exceptions.ArgumentNull(nameof(type));

            var t = type.BaseType;
            while (t != null)
            {
                yield return t;
                t = t.BaseType;
            }
        }
    }
}
