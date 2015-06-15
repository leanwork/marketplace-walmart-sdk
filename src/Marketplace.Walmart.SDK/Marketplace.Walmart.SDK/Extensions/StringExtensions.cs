using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK
{
    internal static class StringExtensions
    {
        public static byte[] CompressWithGzip(this string text)
        {
            //Compress and save buffer
            var output = new MemoryStream();
            using (var gzipStream = new GZipStream(output, CompressionMode.Compress))
            {
                using (var input = new MemoryStream(Encoding.UTF8.GetBytes(text)))
                {
                    input.CopyTo(gzipStream);
                }
            }
            //output.ToArray is still accessible even though output is closed
            byte[] buffer = output.ToArray();

            return buffer;
        }
    }
}
