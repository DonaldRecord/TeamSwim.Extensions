//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;
//using TeamSwim;

//namespace System.Collections.Generic
//{
//    partial class EqualityComparerExt
//    {
//        /// <summary>
//        ///     Returns an instance of <see cref="IEqualityComparer{T}"/>
//        ///     adapted as an instance of <see cref="IEqualityComparer"/>.
//        /// </summary>
//        /// <typeparam name="T">Type of </typeparam>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static IEqualityComparer AsNonGeneric<T>(this IEqualityComparer<T> value)
//        {
//            if (value == null)
//                throw Exceptions.ArgumentNull(nameof(value));

//            var result = EqualityComparerAdapter.DefaultForType(typeof(T));
//            return result;
//        }

//        private class EqualityComparerAdapter
//        {
//            public static IEqualityComparer DefaultForType(Type t)
//            {
//                if (t == null)
//                    throw new ArgumentNullException(nameof(t));

//                var type = typeof(EqualityComparer<>).MakeGenericType(t);
//                var prop = type.GetProperty(nameof(EqualityComparer<int>.Default), BindingFlags.Public | BindingFlags.Static);
//                var comparer = prop.GetValue(null);
//                var result = CreateNonGeneric(t, comparer);
//                return result;
//            }

//            private static IEqualityComparer CreateNonGeneric(Type t, object comparerInstance)
//            {
//                var implType = typeof(ToNonGenericProxy<>).MakeGenericType(t);
//                var instance = Activator.CreateInstance(implType, comparerInstance);
//                var result = (IEqualityComparer)instance;
//                return result;
//            }

//            private class ToNonGenericProxy<T2> : IEqualityComparer
//            {
//                private readonly IEqualityComparer<T2> _genericComparer;

//                public ToNonGenericProxy(IEqualityComparer<T2> comparer)
//                {
//                    _genericComparer = comparer ?? EqualityComparer<T2>.Default;
//                }

//                public int GetHashCode(object obj)
//                {
//                    var t = (T2)obj;
//                    var result = 0;
//                    if (t != null)
//                        result = _genericComparer.GetHashCode(t);
//                    return result;
//                }

//                bool IEqualityComparer.Equals(object x, object y)
//                {
//                    var tx = (T2)x;
//                    var ty = (T2)y;
//                    return _genericComparer.Equals(tx, ty);
//                }

//                public override string ToString() => _genericComparer.ToString() + " (non-generic proxy)";
//            }
//        }
//    }
//}
