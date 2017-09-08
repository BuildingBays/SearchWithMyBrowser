using MadMilkman.Ini;
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
