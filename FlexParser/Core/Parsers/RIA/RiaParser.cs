using System;
using System.Collections.ObjectModel;
using System.Windows;
using AngleSharp.Html.Dom;
using FlexParser.Classes;

namespace FlexParser.RIA
{
    public class RiaParser : IParser
    {
        public ObservableCollection<ParsedInfo> Parse(IHtmlDocument document, string searchString)
        {

            if (document == null)
            {
                MessageBox.Show("Error 2");
                return null;
            }

            var refs = document.QuerySelectorAll("a.list-item__title");
            var headers = document.QuerySelectorAll("a.list-item__title");
            var images = document.QuerySelectorAll("img.responsive_img");
            var dates = document.QuerySelectorAll("div.list-item__date");
            var views = document.QuerySelectorAll("div.list-item__views-text");
            
            ObservableCollection<ParsedInfo> list = new ObservableCollection<ParsedInfo>();
            try
            {
                for (int i = 0; i < refs.Length; i++)
                {
                    if (headers[i].TextContent.Contains(searchString))
                    {
                        list.Add(new ParsedInfo(headers[i].TextContent,
                            refs[i].GetAttribute("href"),
                            images[i].GetAttribute("src"),
                            views[i].TextContent,
                            dates[i].TextContent));
                    }
                }
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show("Error 3");
                return null;
            }
            
            return list;
        }
    }
}