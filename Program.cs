using System;
using System.IO;
using System.Collections.Generic;

namespace webScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var newsScrapter = new NewsScraper();
            var information = newsScrapter.getNews();

            var newsDetails = new NewsDetails();
            var newsKeyWords = new NewsKeyWords();

            var number = 0;

            List<string> allText = new List<string>() { };

            newsKeyWords.SetWords();

            foreach (var info in information)
            {
                number++;
                string text = newsDetails.GetNews(info);
                var keywordsTimes = newsKeyWords.GetKeyWords(text);
                
                var template = File.ReadAllText(@"D:/VisualStudio-rozwiazania/savetxt/template.txt");
                var document = template.Replace("{number}", number.ToString()).Replace("{name}", info.Name).Replace("{keywords}", keywordsTimes).Replace("{href}", info.Href);

                allText.Add(document);
            }

            string fullText = String.Join(" ", allText.ToArray());
            var fife = DateTime.Now.ToString("yyyy-dd-M--HH-mm");
            File.WriteAllText($"D:/VisualStudio-rozwiazania/savetxt/News-{fife}.txt", fullText);
        }
    }
}
