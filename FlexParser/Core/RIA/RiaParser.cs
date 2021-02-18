using System;
using System.Collections.Generic;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using FlexParser.Classes;

namespace FlexParser.RIA
{
    public class RiaParser : IParser
    {
        public string HtmlLoad()
        {
            
            
            return null;
        }
        
        public string[] Parse(IHtmlDocument document)
        {

            if (document == null)
            {
                //Change text from main TextBlock to "Error! Source not specified..."
                //Exit from method
            }

            var refs = document.QuerySelectorAll("a.list-item__title");
            var headers = document.QuerySelectorAll("a.list-item__title");
            var dates = document.QuerySelectorAll("div.list-item__date");
            var views = document.QuerySelectorAll("div.list-item__views-text");
            
            List<string> list = new List<string>();
            try
            {
                string tempString = "";
                for (int i = 0; i < refs.Length; i++)
                {
                    tempString += "<a class = \"header\" href = \"" + refs[i].GetAttribute("src") + "\">";
                    tempString += headers[i].TextContent + "</a>\n";
                    tempString += "<div class = \"date\">" + dates[i].TextContent + "</div>\n";
                    tempString += "<div class = \"views\">" + views[i].TextContent + "</div>\n";
                    
                    list.Add(tempString);
                }
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("!!! - " + exception.Message);
            }

            return list.ToArray();
        }
    }
}