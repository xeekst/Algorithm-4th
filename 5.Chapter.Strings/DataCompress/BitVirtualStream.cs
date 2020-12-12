using System;
using System.Collections;
using System.Collections.Generic;

namespace DataCompress
{
    public class BitVirtualSteam
    {
        private List<bool> _bits;
        private int _offset = 0;

        public bool[] Bits => _bits.ToArray();
        public int Offset => _offset;
        public int Length => _bits.Count;
        public BitVirtualSteam()
        {
            _bits = new List<bool>();
        }

        public BitVirtualSteam(byte[] bytes)
        {
            _bits = new List<bool>();
            for (int i = 0; i < bytes.Length; i++)
            {
                Write(bytes[i]);
            }
        }

        public byte[] GetBytes()
        {
            BitArray tbits = new BitArray(_bits.ToArray());

            //与《算法-第四版》对应长度 补全长度
            byte[] bytes = new byte[Convert.ToInt32(Math.Ceiling(tbits.Length / 8.0))];
            tbits.CopyTo(bytes, 0);
            return bytes;
        }

        public void Seek(int offset)
        {
            _offset = offset;
        }

        public bool ReadBoolean()
        {
            bool v = _bits[_offset++];
            return v;
        }

        public int ReadInt32()
        {
            bool[] array = new bool[32];
            _bits.CopyTo(_offset, array, 0, 32);
            BitArray bitArray = new BitArray(array);
            byte[] bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);
            _offset += 32;
            return BitConverter.ToInt32(bytes);
        }

        public char ReadChar()
        {
            bool[] array = new bool[8];
            _bits.CopyTo(_offset, array, 0, 8);
            BitArray bitArray = new BitArray(array);
            byte[] bytes = new byte[1];
            bitArray.CopyTo(bytes, 0);
            byte b = bytes[0];
            _offset += 8;
            return Convert.ToChar(b);
        }


        public void Write(byte b)
        {
            BitArray array = new BitArray(new byte[] { b });
            for (int i = 0; i < array.Count; i++)
            {
                _bits.Add(array[i]);
            }
        }
        public void Write(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            BitArray array = new BitArray(bytes);
            for (int i = 0; i < array.Count; i++)
            {
                _bits.Add(array[i]);
            }
        }

        public void Write(bool bit)
        {
            _bits.Add(bit);
        }

        public void Write(char ch)
        {
            byte b = Convert.ToByte(ch);
            var bitArray = new BitArray(new byte[] { b });

            for (int i = 0; i < 8; i++)
            {
                _bits.Add(bitArray[i]);
            }
        }
    }
}