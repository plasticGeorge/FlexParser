using AngleSharp.Html.Dom;

namespace FlexParser.Classes
{
    public interface IParser<T> where T : class
    {
        T parseSource(IHtmlDocument document);
    }
}