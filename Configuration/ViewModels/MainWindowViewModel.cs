using MadMilkman.Ini;
using Mvvm;
using SearchWithMyBrowser.Helpers;
using SearchWithMyBrowser.Models;
using System;
using System.IO;

namespace SearchWithMyBrowser.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private Settings _settings;

        public string CustomSearchURL
        {
            get => _settings.CustomURL;
            set
            {
                if (_settings.CustomURL != value)
                {
                    _settings.CustomURL = value;

                    OnPropertyChanged(nameof(CustomSearchURL));
                    OnPropertyChanged(nameof(CustomSearchSample));
                }
            }
        }

        public string CustomSearchSample
        {
            get => _settings.CustomURL.Replace("%{s}", "Hello%20World");
        }

        public SearchEngine SelectedSearchEngine
        {
            get => _settings.EngineSelection;
            set
            {
                if (_settings.EngineSelection != value)
                {
                    _settings.EngineSelection = value;

                    OnPropertyChanged(nameof(SelectedSearchEngine));
                }
            }
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
