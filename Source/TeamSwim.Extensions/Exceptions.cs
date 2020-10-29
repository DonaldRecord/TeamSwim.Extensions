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
    }
}
