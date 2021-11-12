using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    partial class MethodInfoExt
    {
        /// <summary>
        ///     Create delegate from <see cref="MethodInfo"/> instance that can be invoked dynamically.
        /// </summary>
        /// <param name="methodInfo">Source method to create delegate for.</param>
        /// <param name="target">Target of dynamic invocation [if the method is not static].</param>
        /// <returns>A <see cref="Delegate"/> for the specified method.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static Delegate CreateDelegate(
            [NotNull] this MethodInfo methodInfo, 
            [CanBeNull] object target)
        {
            if (methodInfo == null) throw Exceptions.ArgumentNull(nameof(methodInfo));
            if (!methodInfo.IsStatic && target == null)
                throw new ArgumentNullException(nameof(target), "Target cannot be null when the method is not static.");

            Func<Type[], Type> getType;
            var isAction = methodInfo.ReturnType == typeof(void);
            var parameters = methodInfo.GetParameters();
            var types = parameters.Select(p => p.ParameterType);

            if (isAction)
            {
                getType = Expression.GetActionType;
            }
            else
            {
                getType = Expression.GetFuncType;
                types = types.Concat(new[] {methodInfo.ReturnType});
            }

            var result = methodInfo.IsStatic 
                ? Delegate.CreateDelegate(getType(types.ToArray()), methodInfo) 
                : Delegate.CreateDelegate(getType(types.ToArray()), target, methodInfo.Name); // target asserted above

            return result;
        }
    }
}
