using System;
using System.Diagnostics;

namespace SearchWithMyBrowser
{
    class Edge2Browser
    {
        public static void Main(string[] args)
        {
            if (args.Length != 0 && args[0].StartsWith("microsoft-edge:", StringComparison.OrdinalIgnoreCase))
            {
                string url = Protocol2Url.ExtractURL(args[0].Substring(15));

                url = Protocol2Url.ValidateURL(url);

                url = Bing2Google.GetCustomURL(url);

                url = Protocol2Url.ValidateURL(url); // Just in case

                Process.Start(new ProcessStartInfo()
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

    }
}
