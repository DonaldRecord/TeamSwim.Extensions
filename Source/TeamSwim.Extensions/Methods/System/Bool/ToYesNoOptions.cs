using System.ComponentModel;

namespace System
{
    /// <summary>
    ///     Options for returning strings for booleans.
    /// </summary>
    public enum ToYesNoOptions
    {
        /// <summary>
        ///     Lowercase
        /// </summary>
        [Description("Lowercase")]
        Lowercase,

        /// <summary>
        ///     Uppercase
        /// </summary>
        [Description("Uppercase")]
        Uppercase,

        /// <summary>
        ///     Capital
        /// </summary>
        [Description("Capital")]
        Capital
    }
}
