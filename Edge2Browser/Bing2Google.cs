using IniParser;
using System;
using System.IO;
using System.Web;

namespace SearchWithMyBrowser
{
    static class Bing2Google
    {
        private enum SearchEngine
        {
            Custom = 0,
            Google = 1,
            DuckDuckGo = 2,
            Bing = 3
        }

        private class Settings
        {
            internal string CustomEngineString = "https://search.yahoo.com/search?p=%{s}";
            internal SearchEngine Engine = SearchEngine.Google;
        }

        public static string GetCustomURL(string url)
        {
            if (!url.Contains("bing.com/search?q=")) // Not a search URL, nothing to do
                return url;

            var settings = GetUserSettings();
            var uri = new Uri(url);
            var SearchTerm = HttpUtility.ParseQueryString(uri.Query)["q"];

            switch (settings.Engine)
            {
                case SearchEngine.Custom:
                    return settings.CustomEngineString.Replace("%{s}", SearchTerm);
                case SearchEngine.Google:
                    return $"https://www.google.ca/search?q={SearchTerm}";
                case SearchEngine.DuckDuckGo:
                    return $"https://duckduckgo.com/?q={SearchTerm}";
                case SearchEngine.Bing:
                    return url;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static Settings GetUserSettings()
        {
            string file = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SearchWithMyBrowser",
                "config.ini"
            );

            return LoadSettingsFile(file);
        }

        private static Settings LoadSettingsFile(string file)
        {
            var data = new FileIniDataParser().ReadFile(file)["SearchWithMyBrowser"];
            return new Settings()
            {
                CustomEngineString = data["CustomEngineURL"],
                Engine = (SearchEngine)int.Parse(data["Engine"])
            };
        }
    }
}
