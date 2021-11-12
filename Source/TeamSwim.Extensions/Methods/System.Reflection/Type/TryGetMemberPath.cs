//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace System.Reflection
//{
//    partial class TypeExt
//    {
//        /// <summary>
//        ///     
//        /// </summary>
//        /// <param name="type"></param>
//        /// <param name="path"></param>
//        /// <param name="members"></param>
//        /// <param name="accessProperty"></param>
//        /// <returns></returns>
//        public static bool TryGetMemberPath(
//            this Type type,
//            string path,
//            out IList<MemberInfo> members,
//            Func<Type, string, MemberInfo> accessProperty = null)
//        {
//            accessProperty ??= GetDefaultMemberAccessor(DefaultBindingFlags);
//            members = new List<MemberInfo>();
//            var parts = path.Split('.').ToList();

//            var i = 0;
//            foreach (var part in parts)
//            {
//                var property = accessProperty.Invoke(type, part);
//                if (property == null)
//                {
//                    if (i > 0) // they put the canonical object reference at the beginning "root.etc.etc", try again starting at index 1.
//                        return false;
//                    else
//                        continue;
//                }

//                members.Add(property);
//                type = property.T;
//                i++;
//            }

//            return true;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="type"></param>
//        /// <param name="path"></param>
//        /// <param name="properties"></param>
//        /// <param name="bindingFlags"></param>
//        /// <returns></returns>
//        public static bool TryGetMemberPath(
//            this Type type,
//            string path,
//            out IList<PropertyInfo> properties,
//            BindingFlags bindingFlags) =>
//            type.TryGetPropertyPath(path, out properties, GetDefaultMemberAccessor(bindingFlags));

//        private static Func<Type, string, MemberInfo> GetDefaultMemberAccessor(BindingFlags bindingFlags) =>
//            (t, prop) => t.GetProperty(prop, bindingFlags);
//    }
//}
