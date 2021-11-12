using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    partial class TypeExt
    {
        private const BindingFlags DefaultBindingFlags = 
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly;

        /// <summary>
        ///     
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <param name="properties"></param>
        /// <param name="accessProperty"></param>
        /// <returns></returns>
        [PublicAPI]
        public static bool TryGetPropertyPath(
            [NotNull] this Type type,
            [NotNull] string path, 
            out IList<PropertyInfo> properties,
            [CanBeNull] Func<Type, string, PropertyInfo> accessProperty = null)
        {
            if (type == null)
                Exceptions.ArgumentNull(nameof(type));

            accessProperty = accessProperty ?? GetDefaultPropertyAccessor(DefaultBindingFlags);
            properties = new List<PropertyInfo>();
            var parts = path.Split('.').ToList();

            var i = 0;
            foreach (var part in parts)
            {
                var property = accessProperty.Invoke(type, part);
                if (property == null)
                {
                    if (i > 0) // they put the canonical object reference at the beginning "root.etc.etc", try again starting at index 1.
                        return false;
                    else
                        continue;
                }

                properties.Add(property);
                type = property.PropertyType;
                i++;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <param name="properties"></param>
        /// <param name="bindingFlags"></param>
        /// <returns></returns>
        [PublicAPI]
        public static bool TryGetPropertyPath(
            this Type type,
            string path,
            out IList<PropertyInfo> properties,
            BindingFlags bindingFlags) =>
            type.TryGetPropertyPath(path, out properties, GetDefaultPropertyAccessor(bindingFlags));

        private static Func<Type, string, PropertyInfo> GetDefaultPropertyAccessor(BindingFlags bindingFlags) =>
            (t, prop) => t.GetProperty(prop, bindingFlags);
    }
}
