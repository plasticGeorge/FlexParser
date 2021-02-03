namespace FlexParser.Classes
{
    public interface IParserSettings
    {
        string BaseUri { get; set; }

        string Prefix { get; set; }
        
        int StartPoint { get; set; }
        
        int EndPoint { get; set; }
    }
}