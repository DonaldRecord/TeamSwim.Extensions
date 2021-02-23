namespace System.Linq
{
    /// <summary>
    ///     Linq extension method class.
    /// </summary>
    public static partial class LinqExt
    {
        internal static Exception ErrorNoMatch() => new InvalidOperationException();
        internal static Exception ErrorMoreThanOneMatch() => new InvalidOperationException();
    }
}
