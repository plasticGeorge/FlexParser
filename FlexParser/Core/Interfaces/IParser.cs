using System.Collections.ObjectModel;
using AngleSharp.Html.Dom;

namespace FlexParser.Classes
{
    public interface IParser
    {
        ObservableCollection<ParsedInfo> Parse(IHtmlDocument document, string searchString);
    }
}