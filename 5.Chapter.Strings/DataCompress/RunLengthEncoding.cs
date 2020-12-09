using System.Collections.Generic;

namespace DataCompress
{
    public class RunLengthEncoding
    {
        public static byte[] Compress(bool[] bits)
        {
            byte cnt = 0;
            List<byte> bytes = new List<byte>();
            bool b, old = false;
            for (int i = 0; i < bits.Length; i++)
            {
                b = bits[i];
                if (b != old)
                {
                    bytes.Add(cnt);
                    cnt = 0;
                    old = !old;
                }
                else
                {
                    if (cnt == 255)
                    {
                        bytes.Add(cnt);
                        cnt = 0;
                        bytes.Add(0);
                    }
                }
                cnt++;

            }
            bytes.Add(cnt);
            return bytes.ToArray();
        }

        public static bool[] Expand(byte[] bytes)
        {
            List<bool> bs = new List<bool>();
            bool flag = false;
            for (int i = 0; i < bytes.Length; i++)
            {
                byte b = bytes[i];
                for (int k = 0; k < b; b++)
                {
                    bs.Add(flag);
                }
                flag = !flag;
            }
            return bs.ToArray();
        }
    }
}