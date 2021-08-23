using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Reflection
{
    partial class PropertyInfoExt
    {
        /// <summary>
        ///     Returns <see cref="PropertyInfo"/> instances from the source sequence that do not contain any index parameters.
        /// </summary>
        /// <param name="source">Source <see cref="PropertyInfo"/> collection.</param>
        /// <returns><see cref="PropertyInfo"/> instances from the source sequence that do not contain any index parameters.</returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<PropertyInfo> WithoutIndexParameters(this IEnumerable<PropertyInfo> source)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            foreach (var property in source)
            {
                if (property == null)
                    continue;

                var indexParameters = property.GetIndexParameters();
                if (!indexParameters.Any())
                    yield return property;
            }
        }
    }
}
