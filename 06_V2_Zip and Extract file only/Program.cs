using System;
using System.IO;
using System.IO.Compression;

namespace _06_Zip_and_Extract
{
    class Program
    {
        static void Main()
        {
  
            string zipPath = @"..\..\..\oneFileZip.zip";
            string file = @"copyMe.png";

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
