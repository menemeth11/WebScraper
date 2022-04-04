using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Linq; // for skip

namespace webScraper
{
    public class NewsScraper
    {
        private const string onetURL = "https://wiadomosci.onet.pl/";

        public IEnumerable<NewsModel> getNews()
        {
            var web = new HtmlWeb();
            var document = web.Load(onetURL);

            var newsSection = document.QuerySelectorAll("section a"); //.Skip(1)

            foreach (var news in newsSection)
            {
                var namee = news.QuerySelectorAll("span");
                var name = namee[0].InnerText;
                char[] mychar = { ' ', '\n', '&' };

                string nameTrim = name.Trim(mychar).Replace("&quot;", "\"").Replace("quot;", "\""); 

                var href = news.QuerySelector("a").Attributes["href"].Value;

                yield return new NewsModel(nameTrim, href);
            }
        }
    }
}
