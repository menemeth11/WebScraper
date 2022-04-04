using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace webScraper
{
    public class NewsDetails
    {
        public string GetNews(NewsModel news) //void /string
        {
            var web = new HtmlWeb();
            char[] mychar = { ' ', '\n', '&',};

            var document = web.Load(news.Href);
            //document.querySelector("section article section")
            var text = document.QuerySelector("#lead");
            var text2 = document.QuerySelector(".detailContent");
            
            string textAll = text.InnerText + text2.InnerText;
            textAll = textAll.Trim(mychar).Replace("\n", "");
            //Console.WriteLine($"Text tutaj to:\n{textAll.Trim(mychar).Replace("\n", "")}");

            return textAll;
        }
    }
}