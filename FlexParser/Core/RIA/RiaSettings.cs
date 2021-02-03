using FlexParser.Classes;

namespace FlexParser.RIA
{
    public class RiaSettings : IParserSettings
    {
        public string BaseUri { get; set; } = "https://ria.ru/";

        public string Section { get; set; } = "economy";

        public string Prefix { get; set; } = null;

        public int StartPoint { get; set; } = 0;

        public int EndPoint { get; set; } = 0;
    }
}