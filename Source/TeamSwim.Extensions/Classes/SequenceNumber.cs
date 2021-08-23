using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace System
{
    // TODO: implement IConvertible
    /// <summary>
    ///     Number type that increments integer value after every access.
    /// <para>
    ///     Increments will not occur when observing the value with the debugger.
    /// </para>
    /// </summary>
    // ReSharper disable once UseNameofExpression
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class SequenceNumber // : IConvertible
    {
        private int _number;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Func<int> _getNumber;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _seed;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly object _numberLock = new object();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly object _setLock = new object();
        
        /// <summary>
        ///     Default seed value.
        /// </summary>
        public const int DefaultSeed = 0;

        /// <summary>
        ///     Default increment value.
        /// </summary>
        public const int DefaultInterval = 1;

        /// <summary>
        ///     Static implicit operator for <see cref="int"/>.
        /// </summary>
        /// <param name="sn"></param>
        [PublicAPI]
        public static implicit operator int(SequenceNumber sn) => sn.Current();

        /// <summary>
        ///     Seed value used for sequence number.
        /// </summary>
        [PublicAPI]
        public int Seed => _seed;

        /// <summary>
        ///     The increment 
        /// </summary>
        [PublicAPI]
        public int Interval { get; }

        /// <summary>
        ///     Construct new sequence number with specified seed and increment.
        /// </summary>
        /// <param name="seed">Starting number. Default is 0.</param>
        /// <param name="interval">Amount to increment between each retrieval. Default is 1.</param>
        public SequenceNumber(int seed = DefaultSeed, int interval = DefaultInterval)
        {
            _seed = seed;
            Interval = interval;

            lock (_numberLock)
            {
                _number = seed;
            }

            lock (_setLock)
            {
                _getNumber = StartIncrementingNextTime();
            }
        }

        /// <summary>
        ///     Get current sequence number. This will increment to the next number, to be returned on the next call.
        /// </summary>
        /// <returns>Next <see cref="int"/> in sequence.</returns>
        [PublicAPI]
        [MustUseReturnValue]
        // public int Current() => GetNumberThreadSafe();
        public int Current() => _getNumber.Invoke();
        
        /// <summary>
        ///     Fluently skip numbers in the sequence.
        /// </summary>
        /// <param name="times">How many skips should occur. Default is 1.</param>
        /// <returns>Same <see cref="SequenceNumber"/> instance.</returns>
        [PublicAPI]
        public SequenceNumber Skip(int times = 1)
        {
            for (var _ = 0; _ < times; _++)
                IncrementAndGetNumber();
            return this;
        }

        /// <summary>
        ///     Fluently reseed the sequence to the seed specified in the constructor (default is 0).
        /// </summary>
        /// <returns>Same <see cref="SequenceNumber"/> instance.</returns>
        [PublicAPI]
        public SequenceNumber Reseed()
        {
            lock (_numberLock)
            {
                _number = _seed;
                return this;
            }
        }

        /// <summary>
        ///     Fluently reseed the sequence to the seed specified by the <paramref name="newSeed"/> parameter.
        /// <para>
        ///     The <see cref="SequenceNumber"/> instance's seed property will also changed to the <paramref name="newSeed"/> value.
        /// </para>
        /// </summary>
        /// <param name="newSeed">New seed to use for the <see cref="SequenceNumber"/> instance.</param>
        /// <returns>Same <see cref="SequenceNumber"/> instance.</returns>
        [PublicAPI]
        public SequenceNumber Reseed(int newSeed)
        {
            lock (_numberLock)
            {
                _seed = newSeed;
                _number = _seed;
                return this;
            }
        }

        /// <summary>
        ///     Fluently pause the sequence at the next value. This means that accessing a value will not
        ///     increment the sequence until <see cref="Resume(bool)"/> is called
        ///     but will have been incrementing since it was last accessed.
        /// </summary>
        /// <param name="increment">Increment the sequence before next access.</param>
        /// <returns>Same <see cref="SequenceNumber"/> instance.</returns>
        [PublicAPI]
        public SequenceNumber Pause(bool increment)
        {
            if (increment)
            {
                lock (_numberLock)
                {
                    _number += Interval;
                }
            }

            lock (_setLock)
            {
                _getNumber = GetNumberOnly();
            }
            
            return this;
        }

        /// <summary>
        ///    Resume the sequence, if paused.
        /// <para>
        ///     If it was never paused, nothing will happen unless the <paramref name="increment"/> parameter
        ///     is set to <see langword="true"/>. 
        /// </para>
        /// </summary>
        /// <param name="increment">Increment the sequence before next access.</param>
        /// <returns>Same <see cref="SequenceNumber"/> instance.</returns>
        [PublicAPI]
        public SequenceNumber Resume(bool increment)
        {
            //if (increment)
            //{
            //    _getNumber = IncrementAndGetNumber();
            //}
            //else if (_getNumber == GetNumberOnly())
            //{
            //    _getNumber = StartIncrementingNextTime();
            //}

            if (increment)
            {
                lock (_setLock)
                {
                    _getNumber = IncrementAndGetNumber();
                }
            }
            else
            {
                bool getNumberOnly;

                lock (_setLock)
                {
                    getNumberOnly = _getNumber == GetNumberOnly();
                }

                if (getNumberOnly)
                {
                    lock (_setLock)
                    {
                        _getNumber = StartIncrementingNextTime();
                    }
                }
            }

            return this;
        }

        /// <summary>
        ///     Return a enumerated sequence from the output of the sequence.
        /// <para>
        ///     WARNING: Multiple enumeration of this sequence will not work as expected.
        ///     Save as a collection if you need to re-use the values without re-emitting.
        /// </para>
        /// </summary>
        /// <param name="repeat">How long the destination sequence will be</param>
        /// <returns>An <see cref="IEnumerable{T}"/> sequence of <see cref="int"/>.</returns>
        [PublicAPI]
        [Pure, LinqTunnel]
        public IEnumerable<int> AsEnumerable(int repeat)
        {
            if (repeat < 0)
                throw new ArgumentException("Argument cannot be negative.", nameof(repeat));

            if (repeat > 0)
            {
                for (var i = repeat; i > 0; i--)
                    yield return Current();
            }
        }

        private Func<int> IncrementAndGetNumber() => () =>
        {
            lock (_numberLock)
            {
                _number += Interval;
            }

            return GetNumberThreadSafe();
        };

        private Func<int> GetNumberOnly() => GetNumberThreadSafe;

        private Func<int> StartIncrementingNextTime() => () =>
        {
            lock (_setLock)
            {
                _getNumber = IncrementAndGetNumber();
            }

            return GetNumberThreadSafe();
        };

        private int GetNumberThreadSafe()
        {
            int result;

            lock (_numberLock)
            {
                result = _number;
            }

            return result;
        }

        [ExcludeFromCodeCoverage]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object DebuggerDisplay
        {
            get
            {
                lock (_numberLock)
                {
                    if (Interval == 1)
                        return _number;
                    else
                        return $"{_number} | Increment: {Interval}";
                }
            }
        }

        //private IConvertible CurrentConvertible() => Current();
        //public TypeCode GetTypeCode() => CurrentConvertible().GetTypeCode();
        //public bool ToBoolean(IFormatProvider? provider) => CurrentConvertible().ToBoolean(provider);
        //public byte ToByte(IFormatProvider? provider) => CurrentConvertible().ToByte(provider);
        //public char ToChar(IFormatProvider? provider) => CurrentConvertible().ToChar(provider);
        //public DateTime ToDateTime(IFormatProvider? provider) => CurrentConvertible().ToDateTime(provider);
        //public decimal ToDecimal(IFormatProvider? provider) => CurrentConvertible().ToDecimal(provider);
        //public double ToDouble(IFormatProvider? provider) => CurrentConvertible().ToDouble(provider);
        //public short ToInt16(IFormatProvider? provider) => CurrentConvertible().ToInt16(provider);
        //public int ToInt32(IFormatProvider? provider) => CurrentConvertible().ToInt32(provider);
        //public long ToInt64(IFormatProvider? provider) => CurrentConvertible().ToInt64(provider);
        //public sbyte ToSByte(IFormatProvider? provider) => CurrentConvertible().ToSByte(provider);
        //public float ToSingle(IFormatProvider? provider) => CurrentConvertible().ToSingle(provider);
        //public string ToString(IFormatProvider? provider) => CurrentConvertible().ToString(provider);
        //public object ToType(Type conversionType, IFormatProvider? provider) => CurrentConvertible().ToInt64(provider);
        //public ushort ToUInt16(IFormatProvider? provider) => CurrentConvertible().ToUInt16(provider);
        //public uint ToUInt32(IFormatProvider? provider) => CurrentConvertible().ToUInt32(provider);
        //public ulong ToUInt64(IFormatProvider? provider) => CurrentConvertible().ToUInt64(provider);
    }
}
