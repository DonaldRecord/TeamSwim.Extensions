using System.ComponentModel;
using System.Dynamic;
using System.Reflection;

namespace System
{
    /// <summary>
    ///     Options available for special type name formatting options [used in <see cref="TypeNameFormatter"/>].
    /// </summary>
    [Flags]
    public enum TypeNameFormattingOptions
    {
        /// <summary>
        ///     Returns the result of the type's <see cref="MemberInfo.Name"/>.
        /// </summary>
        [Description("Use name only")]
        NameOnly = 0,

        /// <summary>
        ///     Replaces "Nullable&lt;&gt;" with "?". E.G. returns "Int32?" instead of "Nullable&lt;Int32&gt;".
        /// </summary>
        [Description("Use question mark for nullable types")]
        UseQuestionMarkForNullable = 1,

        /// <summary>
        ///     Returns .NET keyword aliases instead of type names. E.G. "string" instead of "String".
        /// <para>
        ///     Using this option overrides the <see cref="FullyQualified"/> option
        ///     for types that have a keyword associated.
        /// </para>
        ///     For enumeration types, the <see cref="UseEnumKeyword"/> must be used to have "enum" returned.
        ///     Otherwise, this flag will only return "enum" when the type being passed in is strictly <see cref="Enum"/>.
        /// </summary>
        [Description("Use keywords")]
        UseKeywords = 2,

        /// <summary>
        ///     Returns the fully qualified type name for the main type and all of the nested types.
        ///     <code>System.Collections.Generic.List&lt;System.String&gt;</code>
        /// <para>
        ///     If the type has a keyword representing it, this option is overridden by <see cref="UseKeywords"/>.
        /// </para>
        /// </summary>
        [Description("Use fully qualified type name")]
        FullyQualified = 4,

        /// <summary>
        ///     Returns "enum" for any Enumeration Type. 
        ///     Returns "System.Enum" when the <see cref="FullyQualified"/> option is also present.
        /// </summary>
        [Description(@"Use ""enum"" keyword")]
        UseEnumKeyword = 8,

        /// <summary>
        ///     Returns the name of <see cref="DynamicObject"/> for any object implementing <see cref="IDynamicMetaObjectProvider"/>.
        /// <para>
        ///     This options respects the <see cref="FullyQualified"/> and <see cref="UseKeywords"/> options.
        /// </para>
        /// </summary>
        [Description("Use dynamic keyword")]
        UseDynamicKeyword = 16,

        /// <summary>
        ///     Default formatting option. Combination of 
        ///     <see cref="UseQuestionMarkForNullable"/> | 
        ///     <see cref="UseKeywords"/> |
        ///     <see cref="UseDynamicKeyword"/>.
        /// </summary>
        [Description("Use default type name formatting options")]
        Default = 19,
    }
}
