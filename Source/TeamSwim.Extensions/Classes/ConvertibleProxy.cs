using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSwim.Extensions.Classes
{
    internal abstract class ConvertibleProxy : IConvertible
    {
        protected abstract IConvertible ConvertibleProxyInstance { get; }

        public TypeCode GetTypeCode() => ConvertibleProxyInstance.GetTypeCode();
        public bool ToBoolean(IFormatProvider? provider) => ConvertibleProxyInstance.ToBoolean(provider);
        public byte ToByte(IFormatProvider? provider) => ConvertibleProxyInstance.ToByte(provider);
        public char ToChar(IFormatProvider? provider) => ConvertibleProxyInstance.ToChar(provider);
        public DateTime ToDateTime(IFormatProvider? provider) => ConvertibleProxyInstance.ToDateTime(provider);
        public decimal ToDecimal(IFormatProvider? provider) => ConvertibleProxyInstance.ToDecimal(provider);
        public double ToDouble(IFormatProvider? provider) => ConvertibleProxyInstance.ToDouble(provider);
        public short ToInt16(IFormatProvider? provider) => ConvertibleProxyInstance.ToInt16(provider);
        public int ToInt32(IFormatProvider? provider) => ConvertibleProxyInstance.ToInt32(provider);
        public long ToInt64(IFormatProvider? provider) => ConvertibleProxyInstance.ToInt64(provider);
        public sbyte ToSByte(IFormatProvider? provider) => ConvertibleProxyInstance.ToSByte(provider);
        public float ToSingle(IFormatProvider? provider) => ConvertibleProxyInstance.ToSingle(provider);
        public string ToString(IFormatProvider? provider) => ConvertibleProxyInstance.ToString(provider);
        public object ToType(Type conversionType, IFormatProvider? provider) => ConvertibleProxyInstance.ToInt64(provider);
        public ushort ToUInt16(IFormatProvider? provider) => ConvertibleProxyInstance.ToUInt16(provider);
        public uint ToUInt32(IFormatProvider? provider) => ConvertibleProxyInstance.ToUInt32(provider);
        public ulong ToUInt64(IFormatProvider? provider) => ConvertibleProxyInstance.ToUInt64(provider);
    }
}
