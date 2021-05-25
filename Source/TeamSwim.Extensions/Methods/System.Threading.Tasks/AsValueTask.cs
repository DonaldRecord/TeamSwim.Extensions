using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Threading.Tasks
{
    partial class TasksExt
    {
        [PublicAPI]
        [Pure]
        public static ValueTask<T> AsValueTask<T>(this T value) => new ValueTask<T>(value);
    }
}
