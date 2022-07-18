using System.Diagnostics;
using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Facade for building custom convertible types.
    /// </summary>
    [PublicAPI]
    [DebuggerDisplay("{ProxyReference}")]
    [Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public abstract class ConvertibleProxy : IConvertible
    {
        /// <summary>
        ///     The <see cref="IConvertible"/> instance to proxy.
        /// </summary>
        [NotNull]
        // protected abstract IConvertible ProxyReference;
        protected abstract IConvertible ProxyReference { get; }

        /// <inheritdoc />
        public TypeCode GetTypeCode() => ProxyReference.GetTypeCode();

        /// <inheritdoc />
        public bool ToBoolean(IFormatProvider provider) => ProxyReference.ToBoolean(provider);
        
        /// <inheritdoc />
        public byte ToByte(IFormatProvider provider) => ProxyReference.ToByte(provider);

        /// <inheritdoc />
        public char ToChar(IFormatProvider provider) => ProxyReference.ToChar(provider);

        /// <inheritdoc />
        public DateTime ToDateTime(IFormatProvider provider) => ProxyReference.ToDateTime(provider);

        /// <inheritdoc />
        public decimal ToDecimal(IFormatProvider provider) => ProxyReference.ToDecimal(provider);

        /// <inheritdoc />
        public double ToDouble(IFormatProvider provider) => ProxyReference.ToDouble(provider);

        /// <inheritdoc />
        public short ToInt16(IFormatProvider provider) => ProxyReference.ToInt16(provider);

        /// <inheritdoc />
        public int ToInt32(IFormatProvider provider) => ProxyReference.ToInt32(provider);

        /// <inheritdoc />
        public long ToInt64(IFormatProvider provider) => ProxyReference.ToInt64(provider);

        /// <inheritdoc />
        public sbyte ToSByte(IFormatProvider provider) => ProxyReference.ToSByte(provider);

        /// <inheritdoc />
        public float ToSingle(IFormatProvider provider) => ProxyReference.ToSingle(provider);

        /// <inheritdoc />
        public string ToString(IFormatProvider provider) => ProxyReference.ToString(provider);

        /// <inheritdoc />
        public object ToType(Type conversionType, IFormatProvider provider) => ProxyReference.ToInt64(provider);

        /// <inheritdoc />
        public ushort ToUInt16(IFormatProvider provider) => ProxyReference.ToUInt16(provider);

        /// <inheritdoc />
        public uint ToUInt32(IFormatProvider provider) => ProxyReference.ToUInt32(provider);

        /// <inheritdoc />
        public ulong ToUInt64(IFormatProvider provider) => ProxyReference.ToUInt64(provider);
    }
}
