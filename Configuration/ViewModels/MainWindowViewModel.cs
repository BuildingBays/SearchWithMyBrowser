using MadMilkman.Ini;
using Mvvm;
using SearchWithMyBrowser.Models;
using System;
using System.IO;

namespace SearchWithMyBrowser.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        Settings _settings;
        public Settings CurrentSettings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        public string CustomSearchURL
        {
            get => CurrentSettings.CustomURL;
            set
            {
                if (CurrentSettings.CustomURL != value)
                {
                    CurrentSettings.CustomURL = value;

                    OnPropertyChanged(nameof(CustomSearchURL));
                    OnPropertyChanged(nameof(CustomSearchSample));
                }
            }
        }

        public string CustomSearchSample
        {
            get => CurrentSettings.CustomURL.Replace("%{s}", "Hello%20World");
        }

        public MainWindowViewModel()
        {
            _settings = LoadUserSettings();
        }

        private Settings LoadUserSettings()
        {
            string file = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SearchWithMyBrowser",
                "config.ini"
            );

            return LoadSettingsFile(file);
        }

        private Settings LoadSettingsFile(string FileName)
        {
            IniFile file = new IniFile();
            file.Load(FileName);
            file.Sections.Add("SearchWithMyBrowser"); // Create Section if it doesn't exists
            IniSection section = file.Sections["SearchWithMyBrowser"];
            return section.Deserialize<Settings>();
        }
    }
}
