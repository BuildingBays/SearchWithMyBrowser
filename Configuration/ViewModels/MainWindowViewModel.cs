using SearchWithMyBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvvm;
using MadMilkman.Ini;
using System.IO;

namespace SearchWithMyBrowser.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        Settings _settings;
        public Settings CurrentSettings
        {
            get => _settings;
            set => SetProperty<Settings>(ref _settings, value, "Settings");
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
            IniSection section = file.Sections.Add("SearchWithMyBrowser");
            return section.Deserialize<Settings>();
        }
    }
}
