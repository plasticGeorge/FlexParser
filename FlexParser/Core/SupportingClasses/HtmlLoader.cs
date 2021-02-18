using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace FlexParser.Classes
{
    public class HtmlLoader
    {
        public async Task<string> HtmlLoad(IParserSettings parserSettings)
        {
            if (parserSettings.StartDate > parserSettings.EndDate)
            {
                MessageBox.Show("Error 5");
                return null;
            }
            string result = "";
            HttpClient httpClient = new HttpClient();
            for (DateTime curDate = parserSettings.StartDate; curDate <= parserSettings.EndDate; curDate = curDate.AddDays(1))
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync($"{parserSettings.BaseUri}{parserSettings.Category}/{curDate.ToString("yyyyMMdd")}");
                result += await responseMessage.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}