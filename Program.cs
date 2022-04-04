using System;
using System.IO;

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

            newsKeyWords.SetWords();

            foreach (var info in information)
            {
                number++;
                //Console.WriteLine($"Nazwa: {info.Name},\nLink: {info.Href}");
                //Console.WriteLine();
                //Console.ReadKey();
                //Console.WriteLine(info.Href);
                string text = newsDetails.GetNews(info);
                var keywordsTimes = newsKeyWords.GetKeyWords(text);
                var one = number.ToString();
                var two = info.Name;
                var tree = keywordsTimes;
                var four = info.Href;
                var fife = DateTime.Now.ToString();
                string[] data = fife.Split(" ");

                var template = File.ReadAllText(@"D:/VisualStudio-rozwiazania/savetxt/template.txt");
                var document = template.Replace("{number}", one).Replace("{name}", two).Replace("{keywords}", tree).Replace("{href}", four);
                /* Console.WriteLine("**************************************************");
                 Console.WriteLine($"Number {number}:");
                 Console.WriteLine($"In the article titled: {info.Name}");
                 Console.WriteLine($"Your keywords come out {keywordsTimes} times!");
                 Console.WriteLine($"You can read this article here!:");
                 Console.WriteLine(info.Href);
                 Console.WriteLine("**************************************************");
                 Console.WriteLine("");*/
                File.WriteAllText($"D:/VisualStudio-rozwiazania/savetxt/news-{data[0]}-{data[1]}.txt", document);
            }
        }
    }
}
