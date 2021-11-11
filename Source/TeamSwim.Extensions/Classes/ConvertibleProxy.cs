using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Facade for building custom convertible types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [PublicAPI]
    public abstract class ConvertibleProxy<T> : IConvertible where T : IConvertible
    {
        /// <summary>
        ///     The <see cref="IConvertible"/> instance to proxy.
        /// </summary>
        [NotNull]
        protected abstract IConvertible ConvertibleProxyInstance { get; }

        /// <inheritdoc />
        public TypeCode GetTypeCode() => ConvertibleProxyInstance.GetTypeCode();

        /// <inheritdoc />
        public bool ToBoolean(IFormatProvider provider) => ConvertibleProxyInstance.ToBoolean(provider);
        
        /// <inheritdoc />
        public byte ToByte(IFormatProvider provider) => ConvertibleProxyInstance.ToByte(provider);

        /// <inheritdoc />
        public char ToChar(IFormatProvider provider) => ConvertibleProxyInstance.ToChar(provider);

        /// <inheritdoc />
        public DateTime ToDateTime(IFormatProvider provider) => ConvertibleProxyInstance.ToDateTime(provider);

        /// <inheritdoc />
        public decimal ToDecimal(IFormatProvider provider) => ConvertibleProxyInstance.ToDecimal(provider);

        /// <inheritdoc />
        public double ToDouble(IFormatProvider provider) => ConvertibleProxyInstance.ToDouble(provider);

        /// <inheritdoc />
        public short ToInt16(IFormatProvider provider) => ConvertibleProxyInstance.ToInt16(provider);

        /// <inheritdoc />
        public int ToInt32(IFormatProvider provider) => ConvertibleProxyInstance.ToInt32(provider);

        /// <inheritdoc />
        public long ToInt64(IFormatProvider provider) => ConvertibleProxyInstance.ToInt64(provider);

        /// <inheritdoc />
        public sbyte ToSByte(IFormatProvider provider) => ConvertibleProxyInstance.ToSByte(provider);

        /// <inheritdoc />
        public float ToSingle(IFormatProvider provider) => ConvertibleProxyInstance.ToSingle(provider);

        /// <inheritdoc />
        public string ToString(IFormatProvider provider) => ConvertibleProxyInstance.ToString(provider);

        /// <inheritdoc />
        public object ToType(Type conversionType, IFormatProvider provider) => ConvertibleProxyInstance.ToInt64(provider);

        /// <inheritdoc />
        public ushort ToUInt16(IFormatProvider provider) => ConvertibleProxyInstance.ToUInt16(provider);

        /// <inheritdoc />
        public uint ToUInt32(IFormatProvider provider) => ConvertibleProxyInstance.ToUInt32(provider);

        /// <inheritdoc />
        public ulong ToUInt64(IFormatProvider provider) => ConvertibleProxyInstance.ToUInt64(provider);
    }
}
