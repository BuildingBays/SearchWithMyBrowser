using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;

namespace SearchWithMyBrowser
{
    static class Edge2Browser
    {
        public static string ExtractURL(string url)
        {
            if (url.StartsWith("?launchContext1=", StringComparison.OrdinalIgnoreCase)) // Handle FCU
            {
                return ExtractFallCreatorsUpdateURL(url);
            }

            return url;
        }

        private static string ExtractFallCreatorsUpdateURL(string url)
        {
            var uri = new Uri(
                HttpUtility.UrlDecode(
                    HttpUtility.ParseQueryString(url)["url"]
                )
            );

            return uri.AbsoluteUri + "?" + HttpUtility.UrlEncode(uri.Query);
        }
    }
}
