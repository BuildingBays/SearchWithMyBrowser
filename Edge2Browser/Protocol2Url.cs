using System;
using System.Diagnostics;

namespace SearchWithMyBrowser
{
    class Protocol2Url
    {
        static void Main(string[] args)
        {
            if (args.Length != 0 && args[0].StartsWith("microsoft-edge:", StringComparison.OrdinalIgnoreCase))
            {
                string url = Edge2Browser.ExtractURL(args[0].Substring(15));

                url = ValidateURL(url);

                Process.Start(new ProcessStartInfo()
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        private static string ValidateURL(string url)
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
