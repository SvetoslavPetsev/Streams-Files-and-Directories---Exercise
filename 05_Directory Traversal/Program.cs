using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _05_Directory_Traversal
{
    class Program
    {
        static void Main()
        {
            var store = new Dictionary<string, Dictionary<string, double>>();
            var dirInfo = new DirectoryInfo(@"..\..\..\..\");

            FileInfo[] allFiles = dirInfo.GetFiles();

            foreach (FileInfo file in allFiles)
            {
                double size = file.Length / 1024d;
                string name = file.Name;
                string extension = file.Extension;

                if (!store.ContainsKey(extension))
                {
                    store.Add(extension, new Dictionary<string, double>());
                }

                var fileInfo = new Dictionary<string, double>();
                store[extension].Add(name, size);
            }

            var sortedReport = store
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";
            foreach (var (extension, value) in sortedReport)
            {
                File.AppendAllText(path, extension + Environment.NewLine);
                foreach (var (file, size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"--{file} - {Math.Round(size, 3)}kb" + Environment.NewLine);
                }
            }
        }
    }
}
