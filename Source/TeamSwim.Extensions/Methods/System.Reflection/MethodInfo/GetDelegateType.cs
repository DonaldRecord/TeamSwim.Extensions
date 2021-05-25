using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace System.Reflection
{
    partial class MethodInfoExt
    {
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
            switch (length)
            {
                case 1:
                    return typeof(Func<>);
                case 2:
                    return typeof(Func<,>);
                case 3:
                    return typeof(Func<,,>);
                case 4:
                    return typeof(Func<,,,>);
                case 5:
                    return typeof(Func<,,,,>);
                case 6:
                    return typeof(Func<,,,,,>);
                case 7:
                    return typeof(Func<,,,,,,>);
                case 8:
                    return typeof(Func<,,,,,,,>);
                case 9:
                    return typeof(Func<,,,,,,,,>);
                case 10:
                    return typeof(Func<,,,,,,,,,>);
                case 11:
                    return typeof(Func<,,,,,,,,,,>);
                case 12:
                    return typeof(Func<,,,,,,,,,,,>);
                case 13:
                    return typeof(Func<,,,,,,,,,,,,>);
                case 14:
                    return typeof(Func<,,,,,,,,,,,,,>);
                case 15:
                    return typeof(Func<,,,,,,,,,,,,,,>);
                case 16:
                    return typeof(Func<,,,,,,,,,,,,,,,>);
                case 17:
                    return typeof(Func<,,,,,,,,,,,,,,,,>);
                default:
                    throw new NotImplementedException();
            }
        }

        private static Type GetActionType(int length)
        {
            switch (length)
            {
                case 0:
                    return typeof(Action);
                case 1:
                    return typeof(Action<>);
                case 2:
                    return typeof(Action<,>);
                case 3:
                    return typeof(Action<,,>);
                case 4:
                    return typeof(Action<,,,>);
                case 5:
                    return typeof(Action<,,,,>);
                case 6:
                    return typeof(Action<,,,,,>);
                case 7:
                    return typeof(Action<,,,,,,>);
                case 8:
                    return typeof(Action<,,,,,,,>);
                case 9:
                    return typeof(Action<,,,,,,,,>);
                case 10:
                    return typeof(Action<,,,,,,,,,>);
                case 11:
                    return typeof(Action<,,,,,,,,,,>);
                case 12:
                    return typeof(Action<,,,,,,,,,,,>);
                case 13:
                    return typeof(Action<,,,,,,,,,,,,>);
                case 14:
                    return typeof(Action<,,,,,,,,,,,,,>);
                case 15:
                    return typeof(Action<,,,,,,,,,,,,,,>);
                case 16:
                    return typeof(Action<,,,,,,,,,,,,,,,>);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
