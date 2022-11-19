using System;

namespace TeamSwim.Features.RelativeOrdering
{
    /// <summary>
    ///     Represents errors from using the relative ordering feature.
    /// </summary>
    public class RelativeOrderException : Exception
    {
        internal RelativeOrderException(string message) : base(message) { }

        internal static RelativeOrderException ForceFirstError(
            RelativeOrderInstruction x, 
            RelativeOrderInstruction y)
            => new RelativeOrderException(
                $"Types '{x.CurrentType}' and '{y.CurrentType}' are both configured with the 'force first' flag. " +
                $"Force first can only be configured for one implementation of {x.SequenceType.FullName}");

        internal static RelativeOrderException ForceLastError(
            RelativeOrderInstruction x,
            RelativeOrderInstruction y)
            => new RelativeOrderException(
                $"Types '{x.CurrentType}' and '{y.CurrentType}' are both configured with the 'force last' flag. " +
                $"Force last can only be configured for one implementation of {x.SequenceType}");

        internal static RelativeOrderException CircularBefore(
            RelativeOrderInstruction x,
            RelativeOrderInstruction y)
            => new RelativeOrderException(
                $"Types '{x.CurrentType}' and '{y.CurrentType}' are both configured to return before one another. " +
                "Only one of these instructions can exist and the other must be removed.");

        internal static RelativeOrderException CircularAfter(
            RelativeOrderInstruction x,
            RelativeOrderInstruction y)
            => new RelativeOrderException(
                $"Types '{x.CurrentType}' and '{y.CurrentType}' are both configured to return after one another. " +
                "Only one of these instructions can exist and the other must be removed.");
    }
}
