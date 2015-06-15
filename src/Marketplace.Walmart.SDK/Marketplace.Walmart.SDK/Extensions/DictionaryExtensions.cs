using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Walmart.SDK
{
    /// <summary>
    /// Dictionary extensions
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Convert dictionary to query string format
        /// </summary>
        /// <param name="data">Dictionary</param>
        /// <returns>Query string format</returns>
        public static string ConvertToQueryString(this Dictionary<string, string> data)
        {
            if (data == null || data.Count == 0)
                return String.Empty;

            string[] _params = data.Select(x => String.Format("{0}={1}", x.Key, x.Value)).ToArray();
            return String.Join("&", _params);
        }
    }
}
