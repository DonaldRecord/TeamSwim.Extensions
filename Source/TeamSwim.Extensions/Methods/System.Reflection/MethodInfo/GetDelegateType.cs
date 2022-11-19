using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace System.Reflection
{
    partial class MethodInfoExt
    {
        /// <summary>
        ///     Get the <see langword="delegate"/> type that correctly identifies the <see cref="MethodInfo"/> signature.
        /// </summary>
        /// <param name="method">The method to determine the signature for.</param>
        /// <returns><see cref="Type"/> that represents the method signature.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Type GetDelegateType([NotNull] this MethodInfo method)
        {
            var returnType = method.ReturnType;
            var isFunc = returnType != typeof(void);

            var parameters = method.GetParameters();
            var parameterTypes = parameters.Select(p => p.ParameterType);

            if (isFunc)
            {
                var args = parameterTypes.Append(returnType).ToList();
                var type = GetFuncType(args.Count);
                var result = type.MakeGenericType(args.ToArray());
                return result;
            }
            else
            {
                var args = parameterTypes.ToList();
                var type = GetActionType(args.Count);
                if (type.IsGenericType)
                {
                    var result = type.MakeGenericType(args.ToArray());
                    return result;
                }
                else
                {
                    return type;
                }
            }
        }

        private static Type GetFuncType(int length)
        {
            return length switch
            {
                1 => typeof(Func<>),
                2 => typeof(Func<,>),
                3 => typeof(Func<,,>),
                4 => typeof(Func<,,,>),
                5 => typeof(Func<,,,,>),
                6 => typeof(Func<,,,,,>),
                7 => typeof(Func<,,,,,,>),
                8 => typeof(Func<,,,,,,,>),
                9 => typeof(Func<,,,,,,,,>),
                10 => typeof(Func<,,,,,,,,,>),
                11 => typeof(Func<,,,,,,,,,,>),
                12 => typeof(Func<,,,,,,,,,,,>),
                13 => typeof(Func<,,,,,,,,,,,,>),
                14 => typeof(Func<,,,,,,,,,,,,,>),
                15 => typeof(Func<,,,,,,,,,,,,,,>),
                16 => typeof(Func<,,,,,,,,,,,,,,,>),
                17 => typeof(Func<,,,,,,,,,,,,,,,,>),
                _ => throw new InvalidOperationException(
                    "Delegate type cannot be built for a method with more than 16 parameters.")
            };
        }

        private static Type GetActionType(int length)
        {
            return length switch
            {
                0 => typeof(Action),
                1 => typeof(Action<>),
                2 => typeof(Action<,>),
                3 => typeof(Action<,,>),
                4 => typeof(Action<,,,>),
                5 => typeof(Action<,,,,>),
                6 => typeof(Action<,,,,,>),
                7 => typeof(Action<,,,,,,>),
                8 => typeof(Action<,,,,,,,>),
                9 => typeof(Action<,,,,,,,,>),
                10 => typeof(Action<,,,,,,,,,>),
                11 => typeof(Action<,,,,,,,,,,>),
                12 => typeof(Action<,,,,,,,,,,,>),
                13 => typeof(Action<,,,,,,,,,,,,>),
                14 => typeof(Action<,,,,,,,,,,,,,>),
                15 => typeof(Action<,,,,,,,,,,,,,,>),
                16 => typeof(Action<,,,,,,,,,,,,,,,>),
                _ => throw new InvalidOperationException(
                    "Delegate type cannot be built for a method with more than 16 parameters.")
            };
        }
    }
}
