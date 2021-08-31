using System;

namespace DOTR.QLess.Infrastructure.Services
{
    /// <summary>
    /// Convenience methods for converting between hex strings and byte array.
    /// </summary>
    public static class ByteConverter
    {
        /// <summary>
        /// Converts the hex representation string to an array of bytes
        /// </summary>
        /// <param name="hexedString">The hexed string.</param>
        /// <returns></returns>
        public static byte[] GetHexBytes(string hexedString)
        {
            var bytes = new byte[hexedString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                var strPos = i * 2;
                var chars = hexedString.Substring(strPos, 2);
                bytes[i] = Convert.ToByte(chars, 16);
            }
            return bytes;
        }
        /// <summary>
        /// Gets a hex string representation of the byte array passed in.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        public static string GetHexString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
        }
    }
}
