using System;

namespace FlexParser.Classes
{
    public interface IParserSettings
    {
        string BaseUri { get; set; }
        
        string Category { get; set; }
        
        string SearchString { get; set; }
        
        DateTime StartDate { get; set; }
        
        DateTime EndDate { get; set; }
    }
}