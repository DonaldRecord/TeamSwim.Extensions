//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using JetBrains.Annotations;

//namespace System
//{
//    public static partial class AttributeExt
//    {
//        public static bool? AllowsMultiple<T>() where T : Attribute
//        {
//            var type = typeof(T);

//            var attr = type.GetCustomAttribute<AttributeUsageAttribute>();

//            return attr?.AllowMultiple;
//        }
//    }
//}
