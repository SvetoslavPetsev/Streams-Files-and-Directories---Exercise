using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _03_Word_Count
{
    class Program
    {
        static void Main()
        {
            string[] findWords = File.ReadAllLines("words.txt");
            string[] text = File.ReadAllLines("text.txt");

            var wordsAndCount = new Dictionary<string, int>();
            foreach (var word in findWords)
            {
                string currWordToLower = word.ToLower();
                if (!wordsAndCount.ContainsKey(currWordToLower))
                {
                    wordsAndCount.Add(currWordToLower, 0);
                }

            }

            foreach (var line in text)
            {
                string[] lineArr = line.ToLower().Split(new char[] { ' ', '-', ',', '.', '!', '?' });
                foreach (var word in lineArr)
                {
                    if (findWords.Contains(word))
                    {
                        wordsAndCount[word]++;
                    }

                }

            }

            for (int i = 0; i < findWords.Length; i++)
            {
                if (wordsAndCount.ContainsKey(findWords[i]))
                {
                    findWords[i] += $" - {wordsAndCount[findWords[i]]}";
                }

            }

            string actualResult = "actualResult.txt";
            string expectedResult = "expectedResult.txt";

            foreach (var (word, count) in wordsAndCount)
            {
                File.AppendAllText(actualResult, $"{word} - {count}{Environment.NewLine}");
            }

            foreach (var (word, count) in wordsAndCount.OrderByDescending(x=>x.Value))
            {
                File.AppendAllText(expectedResult, $"{word} - {count}{Environment.NewLine}");
            }
        }
    }
}
