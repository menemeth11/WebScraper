using System;
using System.Collections.Generic;
using System.Text;

namespace webScraper
{
    public class NewsModel
    {
        public NewsModel(string name, string href)
        {
            Name = name;
            Href = href;
        }

        public string Name { get; set; }
        public string Href { get; set; }
    }
}
