using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace webScraper
{
    public class NewsDetails
    {
        public string GetNews(NewsModel news)
        {
            var web = new HtmlWeb();
            char[] mychar = { ' ', '\n', '&',};

            var document = web.Load(news.Href);

            var text = document.QuerySelector("#lead");
            var text2 = document.QuerySelector(".detailContent");
            
            string textAll = text.InnerText + text2.InnerText;
            textAll = textAll.Trim(mychar).Replace("\n", "");

            return textAll;
        }
    }
}