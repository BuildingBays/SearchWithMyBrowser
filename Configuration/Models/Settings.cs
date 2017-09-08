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
    public class Settings
    {
        [IniSerialization("CustomEngineURL")]
        public string CustomURL { get; set; } = "https://search.yahoo.com/search?p=%{s}";

        [IniSerialization("Engine")]
        public SearchEngine EngineSelection { get; set; } = SearchEngine.Google;
    }
}
