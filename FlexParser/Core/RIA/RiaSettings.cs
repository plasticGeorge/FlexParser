using FlexParser.Classes;

namespace FlexParser.RIA
{
    public class RiaSettings
    {
        RiaSettings(string searchString,
            string section)
        {
            SearchString = searchString;
            Section = section;
        }
        
        public string SearchString { get; set; }
        public string BaseUri { get; set; } = "https://ria.ru/";

        public string Section { get; set; }

        public string Prefix { get; set; } = null;

        public int StartPoint { get; set; } = -1;

        public int EndPoint { get; set; } = -1;
    }
}