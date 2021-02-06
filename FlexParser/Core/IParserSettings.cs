using System;
using System.Net.Http;

namespace FlexParser.Classes
{
    public interface IParserSettings
    {
        string BaseUri { get; set; }
        
        string Category { get; set; }
        
        DateTime StartDate { get; set; }
        
        DateTime EndDate { get; set; }

        string getNextPagesUri(string response);
    }
}