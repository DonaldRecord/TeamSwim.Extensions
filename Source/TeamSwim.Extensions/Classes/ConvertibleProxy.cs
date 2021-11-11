using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Facade for building custom convertible types.
    /// </summary>
    [PublicAPI]
    public abstract class ConvertibleProxy : IConvertible
    {
        /// <summary>
        ///     The <see cref="IConvertible"/> instance to proxy.
        /// </summary>
        [NotNull]
        protected abstract IConvertible GetConvertibleProxy();

        /// <inheritdoc />
        public TypeCode GetTypeCode() => GetConvertibleProxy().GetTypeCode();

        /// <inheritdoc />
        public bool ToBoolean(IFormatProvider provider) => GetConvertibleProxy().ToBoolean(provider);
        
        /// <inheritdoc />
        public byte ToByte(IFormatProvider provider) => GetConvertibleProxy().ToByte(provider);

        /// <inheritdoc />
        public char ToChar(IFormatProvider provider) => GetConvertibleProxy().ToChar(provider);

        /// <inheritdoc />
        public DateTime ToDateTime(IFormatProvider provider) => GetConvertibleProxy().ToDateTime(provider);

        /// <inheritdoc />
        public decimal ToDecimal(IFormatProvider provider) => GetConvertibleProxy().ToDecimal(provider);

        /// <inheritdoc />
        public double ToDouble(IFormatProvider provider) => GetConvertibleProxy().ToDouble(provider);

        /// <inheritdoc />
        public short ToInt16(IFormatProvider provider) => GetConvertibleProxy().ToInt16(provider);

        /// <inheritdoc />
        public int ToInt32(IFormatProvider provider) => GetConvertibleProxy().ToInt32(provider);

        /// <inheritdoc />
        public long ToInt64(IFormatProvider provider) => GetConvertibleProxy().ToInt64(provider);

        /// <inheritdoc />
        public sbyte ToSByte(IFormatProvider provider) => GetConvertibleProxy().ToSByte(provider);

        /// <inheritdoc />
        public float ToSingle(IFormatProvider provider) => GetConvertibleProxy().ToSingle(provider);

        /// <inheritdoc />
        public string ToString(IFormatProvider provider) => GetConvertibleProxy().ToString(provider);

        /// <inheritdoc />
        public object ToType(Type conversionType, IFormatProvider provider) => GetConvertibleProxy().ToInt64(provider);

        /// <inheritdoc />
        public ushort ToUInt16(IFormatProvider provider) => GetConvertibleProxy().ToUInt16(provider);

        /// <inheritdoc />
        public uint ToUInt32(IFormatProvider provider) => GetConvertibleProxy().ToUInt32(provider);

        /// <inheritdoc />
        public ulong ToUInt64(IFormatProvider provider) => GetConvertibleProxy().ToUInt64(provider);
    }
}
