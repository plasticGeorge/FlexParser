using AngleSharp.Html.Dom;

namespace FlexParser.Classes
{
    public interface IParser
    {
        string[] Parse(IHtmlDocument document);
    }
}