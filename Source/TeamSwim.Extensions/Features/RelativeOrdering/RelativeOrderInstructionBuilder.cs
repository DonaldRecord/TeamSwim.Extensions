using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TeamSwim.Features.RelativeOrdering
{
    /// <summary>
    ///     Builder of relative ordering instructions for instances of <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">Element type to use ordering. The collection</typeparam>
    [DebuggerDisplay("{_instruction.CurrentType}")]
    public class RelativeOrderInstructionBuilder<T>
    {
        private readonly RelativeOrderInstruction _instruction;

        internal RelativeOrderInstructionBuilder(Type currentType) =>
            _instruction = new RelativeOrderInstruction(currentType, typeof(T));

        internal RelativeOrderInstruction Build() => _instruction;

        /// <summary>
        ///     Yield before any instances of <typeparamref name="TOther"/> are yielded.
        /// </summary>
        /// <typeparam name="TOther">Type to come after.</typeparam>
        public RelativeOrderInstructionBuilder<T> Before<TOther>() => this
            .Fluent(() => _instruction.BeforeInstructions.Add(typeof(TOther)));

        /// <summary>
        ///     Yield after any instances of <typeparamref name="TOther"/> are yielded.
        /// </summary>
        /// <typeparam name="TOther">Type to come before.</typeparam>
        public RelativeOrderInstructionBuilder<T> After<TOther>() => this
            .Fluent(() => _instruction.AfterInstructions.Add(typeof(TOther)));

        /// <summary>
        ///     Yield first. If multiple elements are set up with the force flag,
        ///     a <see cref="RelativeOrderException"/> will be thrown when they are compared.
        /// </summary>
        public RelativeOrderInstructionBuilder<T> ForceFirst() => First(true);

        /// <summary>
        ///     Yield first. Multiple elements can be marked first but when they are compared,
        ///     the element that is first in the sequence will be the first one returned.
        /// </summary>
        /// <param name="force">
        ///     Force the element to be first. If multiple elements are set up with a force flag,
        ///     a <see cref="RelativeOrderException"/> will be thrown when they are compared.
        /// </param>
        public RelativeOrderInstructionBuilder<T> First(bool force = false) => this
            .Fluent(() => _instruction.FirstFlag = true)
            .Fluent(() => _instruction.FirstFlagForce = force);

        /// <summary>
        ///     Yield first. If multiple elements are set up with the force flag,
        ///     a <see cref="RelativeOrderException"/> will be thrown when they are compared.
        /// </summary>
        public RelativeOrderInstructionBuilder<T> ForceLast() => Last(true);

        /// <summary>
        ///     Yield last. Multiple elements can be marked last but when they are compared,
        ///     the element that is first in the sequence will be the first one returned.
        /// </summary>
        /// <param name="force">
        ///     Force the element to be first. If multiple elements are set up with a force flag,
        ///     a <see cref="RelativeOrderException"/> will be thrown when they are compared.
        /// </param>
        public RelativeOrderInstructionBuilder<T> Last(bool force = false) => this
            .Fluent(() => _instruction.LastFlag = true)
            .Fluent(() => _instruction.LastFlagForce = force);

        /// <summary>
        ///     Set up a "RunOrder" for an element, meaning any elements with a lower ordinal
        ///     will be returned before it and vice versa.
        /// </summary>
        /// <param name="ordinal">Run Order.</param>
        public RelativeOrderInstructionBuilder<T> WithOrdinal(int ordinal) => this
            .Fluent(() => _instruction.Ordinal = ordinal);
    }
}
