using System;
using System.Text;
using System.Linq;
using System.IO;

namespace _01__Even_Lines
{
    class Program
    {
        static void Main()
        {
            string pathInput = @"..\..\..\text.txt";

            using var stream = new StreamReader(pathInput);
            {
                int counter = 0;
                string text;
                while ((text = stream.ReadLine())!= null)
                {
                    string tempTemp = text;
                    if (counter % 2 == 0)
                    {
                        char[] symbolForReplace = new char[] { '-', ',', '.', '!', '?' };
                        char newSymbol = '@';
                        foreach (var symbol in tempTemp)
                        {
                            if (symbolForReplace.Contains(symbol))
                            {
                                text = text.Replace(symbol, newSymbol);
                            }

                        }

                        string result = string.Join(" ", text.Split().Reverse());
                        Console.WriteLine(result);
                    }
                    counter++;
                }    
            }
        }
    }
}

