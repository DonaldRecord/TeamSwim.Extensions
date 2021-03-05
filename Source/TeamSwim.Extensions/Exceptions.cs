using System;

namespace TeamSwim
{
    internal static class Exceptions
    {
        internal static NullReferenceException NullRef()
        {
            return new NullReferenceException {Source = TeamSwimExtensions.ExceptionSource};
        }

        internal static ArgumentNullException ArgumentNull(string paramName)
        {
            return new ArgumentNullException(paramName) {Source = TeamSwimExtensions.ExceptionSource};
        }

        internal static Exception ErrorNoMatch()
        {
            return new InvalidOperationException("Sequence contains no elements") {Source = TeamSwimExtensions.ExceptionSource};
        }

        internal static Exception ErrorMoreThanOneMatch()
        {
            return new InvalidOperationException("Sequence contains more than one element") {Source = TeamSwimExtensions.ExceptionSource};
        }
    }
}
