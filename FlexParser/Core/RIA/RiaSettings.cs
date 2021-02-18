using System;
using FlexParser.Classes;

namespace FlexParser.RIA
{
    public class RiaSettings : IParserSettings
    {
        public string BaseUri { get; set; } = "https://ria.ru/";

        public string Category { get; set; }
        public string SearchString { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}