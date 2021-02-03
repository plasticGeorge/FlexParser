using System.Net;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace FlexParser.Classes
{
    public class HtmlLoader
    {
        private readonly string uri;

        HtmlLoader(IParserSettings parserSettings)
        {
            uri = $"{parserSettings.BaseUri}/{parserSettings.Prefix}/";
        }

        IHtmlDocument loadingFromSource(IParserSettings parserSettings) => new HtmlParser().ParseDocument(
            ((HttpWebResponse) ((HttpWebRequest) WebRequest.Create(uri)).GetResponse()).GetResponseStream());
    }
}