using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace System.Linq.Expressions
{
    partial class PropertyInfoExt
    {
        //public static LambdaExpression CreateEqualsExpression(
        //    this PropertyInfo propertyInfo,
        //    Expression rightHandExpression)
        //{
        //    var declaringType = propertyInfo.DeclaringType ?? throw new NotImplementedException();
        //    var parameter = Expression.Parameter(declaringType, "x");
        //    var result = Expression.Lambda(
        //        Expression.Equal(
        //            Expression.Property(parameter, propertyInfo),
        //            rightHandExpression),
        //        parameter);
        //    return result;
        //}
    }
}