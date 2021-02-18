using AngleSharp.Html.Dom;

namespace FlexParser.Classes
{
    public interface IParser
    {
        string HtmlLoad();
        string[] Parse(IHtmlDocument document);
    }
}