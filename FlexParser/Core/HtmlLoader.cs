using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Parser.Tokens;

namespace FlexParser.Classes
{
    public class HtmlLoader
    {
        private IParserSettings parserSettings;
        private string uri;

        private readonly HttpClient client = new HttpClient();
        
        HtmlLoader(IParserSettings parserSettings)
        {
            this.parserSettings = parserSettings;
            uri = $"{parserSettings.BaseUri}/{parserSettings.Category}";
        }

        public async Task<string> HtmlLoad(IParserSettings parserSettings)
        {
            HttpResponseMessage response;
            string source = "";

            for (string tempString = "", curUri = uri; String.IsNullOrEmpty(curUri); curUri = tempString)
            {
                response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                tempString = await response.Content.ReadAsStringAsync();
                source += tempString;
            }

            return source;
        }
    }
}