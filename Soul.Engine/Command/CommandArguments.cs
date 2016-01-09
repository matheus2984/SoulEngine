using System;
using System.Collections.Generic;

namespace Soul.Engine.Command
{
    public class CommandArguments
    {
        private readonly IEnumerator<string> _enum;
        public bool TargetedCommand;

        public CommandArguments(IEnumerable<string> args, bool targetCommand = false)
        {
            _enum = args.GetEnumerator();
            TargetedCommand = targetCommand;
        }

        public CommandArguments ResetEnumerator()
        {
            _enum.Reset();
            return this;
        }

        public bool NextBoolean(bool? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (bool) def;

                throw new Exception();
            }

            bool value;
            if (bool.TryParse(_enum.Current, out value))
                return value;

            string w = _enum.Current.ToLower();
            if (w.Contains("yes"))
                return true;
            if (w.Contains("no"))
                return false;

            throw new Exception();
        }

        public char NextChar(char? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (char) def;

                throw new Exception();
            }

            char value;
            if (char.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public byte NextByte(byte? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (byte) def;

                throw new Exception();
            }

            byte value;
            if (byte.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

    //    [CLSCompliant(false)]
        public sbyte NextSByte(sbyte? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (sbyte) def;

                throw new Exception();
            }

            sbyte value;
            if (sbyte.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

     //   [CLSCompliant(false)]
        public ushort NextUInt16(ushort? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (ushort) def;

                throw new Exception();
            }

            ushort value;
            if (ushort.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public short NextInt16(short? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (short) def;

                throw new Exception();
            }

            short value;
            if (short.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

      //  [CLSCompliant(false)]
        public uint NextUInt32(uint? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (uint) def;

                throw new Exception();
            }

            uint value;
            if (uint.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public int NextInt32(int? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (int) def;

                throw new Exception();
            }

            int value;
            if (int.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

       // [CLSCompliant(false)]
        public ulong NextUInt64(ulong? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (ulong) def;

                throw new Exception();
            }

            ulong value;
            if (ulong.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public long NextInt64(long? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (long) def;

                throw new Exception();
            }

            long value;
            if (long.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public float NextSingle(float? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (float) def;

                throw new Exception();
            }

            float value;
            if (float.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public double NextDouble(double? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (double) def;

                throw new Exception();
            }

            double value;
            if (double.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public decimal NextDecimal(decimal? def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return (decimal) def;

                throw new Exception();
            }

            decimal value;
            if (decimal.TryParse(_enum.Current, out value))
                return value;

            throw new Exception();
        }

        public string NextString(string def = null)
        {
            if (!_enum.MoveNext())
            {
                if (def != null)
                    return def;

                throw new Exception();
            }

            string value = _enum.Current;
            return value;
        }

        public T NextEnum<T>(T? def = null)
            where T : struct
        {
            if (!typeof (T).IsEnum)
                throw new Exception("Invalid type.");

            T value;
            if (Enum.TryParse(NextString(def != null ? def.ToString() : null), true, out value))
                return value;

            throw new Exception();
        }
    }
}