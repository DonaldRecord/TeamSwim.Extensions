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
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="obj">Target object.</param>
        /// <param name="routineWithObjReference">Fluent setter.</param>
        /// <returns><paramref name="obj"/> after fluent setter runs.</returns>
        [PublicAPI]
        [MustUseReturnValue]
        public static T Fluent<T>(
            [NotNull] this T obj,
            [NotNull, InstantHandle] Action<T> routineWithObjReference)
        {
            if (obj == null) throw Exceptions.ArgumentNull(nameof(obj));
            if (routineWithObjReference == null) throw Exceptions.ArgumentNull(nameof(routineWithObjReference));

            routineWithObjReference.Invoke(obj);
            return obj;
        }

        /// <summary>
        ///     (Opinionated)
        ///     Short-hand of writing a fluent method.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="obj">Target object.</param>
        /// <param name="routine">Fluent setter.</param>
        /// <returns><paramref name="obj"/> after fluent setter runs.</returns>
        [PublicAPI]
        [MustUseReturnValue]
        public static T Fluent<T>(
            [NotNull] this T obj,
            [NotNull, InstantHandle] Action routine)
        {
            if (obj == null) throw Exceptions.ArgumentNull(nameof(obj));
            if (routine == null) throw Exceptions.ArgumentNull(nameof(routine));

            routine.Invoke();
            return obj;
        }
    }
}
