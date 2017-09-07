using IniParser;
using System;
using System.IO;

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

        private struct Settings
        {
            internal string CustomEngineString;
            internal SearchEngine Engine;
        }

        public static string GetCustomURL(string url)
        {
            var settings = GetUserSettings();
            return $"{settings.CustomEngineString} {settings.Engine}";
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
