using System;
using System.Collections.Generic;
using System.Text;

namespace webScraper
{
    public class NewsKeyWords
    {
        List<string> keyWords = new List<string>() { };

        public void SetWords()
        {
            Console.WriteLine("How many keywords do you want to enter?:  ");
            var wordsAmount = int.Parse(Console.ReadLine());

            for (int i = 0; i < wordsAmount; i++)
            {
                Console.WriteLine($"Enter key word number {i + 1}: ");
                string addWord = Console.ReadLine();
                keyWords.Add(addWord);
            }
        }


        public string GetKeyWords(string text)
        {
            string[] splitText = text.Split(" ");

            int appearances = 0;

            foreach (var word in splitText)
            {
                if (keyWords.Contains(word))
                {
                    appearances += 1;
                }
            }
            return appearances.ToString();
        }
    }
}
