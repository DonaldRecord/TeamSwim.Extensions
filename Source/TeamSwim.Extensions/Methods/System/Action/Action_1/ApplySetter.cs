using JetBrains.Annotations;
using TeamSwim;

namespace System
{
    partial class ActionExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Constructs a new instance of <typeparamref name="T"/> 
        ///     and applies the specified method body to the newly created instance.
        /// </summary>
        /// <typeparam name="T">Type manipulated by method body.</typeparam>
        /// <param name="setter">Setter method body.</param>
        /// <returns>Instance of <typeparamref name="T"/> after the setter method has been run using it.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="setter"/> is <see langword="null"/></exception>
        /// <exception cref="Exception">Setter delegate callback throws an exception.</exception>
        [PublicAPI]
        [MustUseReturnValue, NotNull]
        public static T ApplySetter<T>([NotNull, InstantHandle] this Action<T> setter) where T : new()
        {
            if (setter == null) throw Exceptions.ArgumentNull(nameof(setter));

            var t = new T();
            setter.Invoke(t);
            return t;
        }
    }
}
