using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TeamSwim.Features.RelativeOrdering
{
    /// <summary>
    ///     Configures the current type to have instructions on how to relatively
    ///     order it within a sequence of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Element type of sequences that can be ordered with the current instructions.</typeparam>
    public interface IRelativeOrderEnabled<T>
    {
        /// <summary>
        ///     Configure the instructions for relative ordering for sequences of <typeparamref name="T"/>.
        /// </summary>
        Action<RelativeOrderInstructionBuilder<T>> Setup { get; }
    }
}
