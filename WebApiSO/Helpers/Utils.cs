using System.IO;

namespace WebApiSO.Helpers
{
    public static class Utils
    {
        /// <summary>
        /// <see cref="StreamToByteArrayUsingBinaryReader"/>: Convert Stream to Byte Array With the BinaryReader Class.
        /// </summary>
        /// <param name="stream">The stream value</param>
        /// <returns>An instance of the <see cref="byte"/> array.</returns>
        public static byte[] StreamToByteArrayUsingBinaryReader(Stream stream)
        {
            byte[] bytes;
            using (var binaryReader = new BinaryReader(stream))
            {
                bytes = binaryReader.ReadBytes((int)stream.Length);
            }
            return bytes;
        }
    }
}
