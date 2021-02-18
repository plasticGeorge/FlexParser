namespace FlexParser.Classes
{
    public class ParsedInfo
    {
        public ParsedInfo(string header, string reference, string imagePath, string views, string date)
        {
            Header = header;
            Reference = reference;
            ImagePath = imagePath;
            Views = views;
            Date = date;
        }
        
        public string Header { get; set; }
        public string Reference { get; set; }
        public string ImagePath { get; set; }
        public string Views { get; set; }
        public string Date { get; set; }
    }
}