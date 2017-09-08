using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadMilkman.Ini;
using Mvvm;
using SearchWithMyBrowser.Helpers;

namespace SearchWithMyBrowser.Models
{
    public class Settings : BindableBase
    {
        private string _customURL = "https://search.yahoo.com/search?p=%{s}";

        [IniSerialization("CustomEngineURL")]
        public string CustomURL
        {
            get => _customURL;
            set => SetProperty(ref _customURL, value, "CustomURL");
        }

        private SearchEngine _searchEngine = SearchEngine.Google;

        [IniSerialization("Engine")]
        public SearchEngine EngineSelection
        {
            get => _searchEngine;
            set => SetProperty(ref _searchEngine, value, "EngineSelection");
        }
    }
}
