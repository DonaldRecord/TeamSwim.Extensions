﻿using JetBrains.Annotations;

namespace System
{
    partial class ObjectExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Version of <see cref="Object.Equals(object, object)"/> that is safe with <see langword="null"/> objects.
        ///     Will return <see langword="true"/> if both objects are <see langword="null"/>.
        /// </summary>
        /// <param name="objA"><see cref="object"/> A to be compared.</param>
        /// <param name="objB"><see cref="object"/> B to be compared.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static bool NullEquals(
            [CanBeNull, NoEnumeration] this object objA,
            [CanBeNull, NoEnumeration] object objB)
        {
            if (objA == null)
                return objB == null;
            else
                return objB != null && Equals(objA, objB);
        }
    }
}
