namespace Ditch
{
    public class ConvertHelper
    {
        /// <summary>
        /// https://github.com/xeroc/python-graphenelib/blob/master/graphenebase/types.py
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static byte[] VarInt(int n)
        {
            //get array len
            var i = 1;
            var k = n;
            while (k >= 0x80)
            {
                k >>= 7;
                i++;
            }

            var data = new byte[i];
            i = 0;

            while (n >= 0x80)
            {
                data[i++] = (byte)(0x80 | (n & 0x7f));
                n >>= 7;
            }

            data[i] += (byte)n;
            return data;
        }
    }
}
