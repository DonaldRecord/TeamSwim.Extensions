using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    partial class MethodInfoExt
    {
        /// <summary>
        ///     Special name of .NET's equality operator method.
        /// </summary>
        public const string EqualityOperatorName = "op_Equality";

        /// <summary>
        ///     Determines if the specified method is the .NET equality operator method.
        /// </summary>
        /// <param name="methodInfo">Potential equality operator method.</param>
        /// <returns><see langword="true"/> if the specified method is the .NET equality operator method. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool IsEqualityOperator([NotNull] this MethodInfo methodInfo)
        {
            if (methodInfo == null) throw Exceptions.ArgumentNull(nameof(methodInfo));

            var result = methodInfo.IsSpecialName && methodInfo.Name.Equals(EqualityOperatorName);
            return result;
        }
    }
}
