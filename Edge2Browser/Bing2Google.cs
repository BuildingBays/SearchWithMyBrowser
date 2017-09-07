using IniParser;
using System;
using System.IO;

namespace SearchWithMyBrowser
{
    static class Bing2Google
    {
        private enum SearchEngine
        {
            Google = 1,
            DuckDuckGo = 2,
            Bing = 3
        }

        private struct Settings
        {
            internal bool CustomEngineSelected;
            internal string CustomEngineString;
            internal SearchEngine Engine;
        }

        public static string GetCustomURL(string url)
        {
            return "lol";
        }

        private static Settings GetUsersSettings()
        {
            string file = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
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
                CustomEngineSelected = data["UseCustomEngine"].Equals("true"),
                CustomEngineString = data["CustomEngineURL"],
                Engine = (SearchEngine)int.Parse(data["Engine"])
            };
        }
    }
}
