using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System
{
    partial class ObjectExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Short-hand of writing a fluent method.
        /// </summary>
        /// <typeparam name="T">Object to </typeparam>
        /// <param name="obj"></param>
        /// <param name="routine"></param>
        /// <returns></returns>
        [PublicAPI]
        [MustUseReturnValue]
        public static T Fluent<T>(
            [NotNull] this T obj,
            [NotNull, InstantHandle] Action<T> routine)
        {
            if (obj == null) throw Exceptions.ArgumentNull(nameof(obj));
            if (routine == null) throw Exceptions.ArgumentNull(nameof(routine));

            routine.Invoke(obj);
            return obj;
        }
    }
}
