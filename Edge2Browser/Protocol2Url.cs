using System;
using System.Web;

namespace SearchWithMyBrowser
{
    static class Protocol2Url
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

        public static string ValidateURL(string url)
        {
            if (url.StartsWith("//"))
                url = url.Substring(2);

            if (!BeginsWithHTTP(url))
                url = "http://" + url;

            if (IsValidURL(url))
                return url;
            else
                throw new UriFormatException();
        }

        private static bool IsValidURL(string url) => Uri.IsWellFormedUriString(url, UriKind.Absolute) && BeginsWithHTTP(url);
        private static bool BeginsWithHTTP(string url) => url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
    }
}
