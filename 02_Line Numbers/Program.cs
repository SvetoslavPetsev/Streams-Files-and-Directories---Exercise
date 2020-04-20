using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _02_Line_Numbers
{
    class Program
    {
        static void Main()
        {
            string pathInput = "text.txt";
            string pathOutput = "output.txt";

            string[] textLine = File.ReadAllLines(pathInput);

            int lineCounter = 1;

            foreach (var line in textLine)
            {
                int letterCount = line.Count(char.IsLetter);
                int punctCount = line.Count(char.IsPunctuation);
                char[] arr = line.ToCharArray();

                string result = $"Line {lineCounter}: {line} ({letterCount})({punctCount}){Environment.NewLine}";
                File.AppendAllText(pathOutput, result);

                lineCounter++;
            }
        }
    }
}
