using System;

namespace TeamSwim
{
    internal static class Exceptions
    {
        public static NullReferenceException NullRef()
        {
            return new NullReferenceException {Source = TeamSwimExtensions.ExceptionSource};
        }

        public static ArgumentNullException ArgumentNull(string paramName)
        {
            return new ArgumentNullException(paramName) {Source = TeamSwimExtensions.ExceptionSource};
        }
    }
}
