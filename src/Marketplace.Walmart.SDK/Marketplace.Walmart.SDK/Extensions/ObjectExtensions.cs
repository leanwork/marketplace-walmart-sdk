using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Marketplace.Walmart.SDK
{
    /// <summary>
    /// Object extensions
    /// </summary>
    internal static class ObjectExtensions
    {
        /// <summary>
        /// Convert any object to byte array
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Byte array</returns>
        public static byte[] ConvertToByte(this object obj)
        {
            if (obj == null)
            {   
                return new byte[0];
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        public static string ToJSON(this object obj)
        {
            var settings = new JsonSerializerSettings();
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}