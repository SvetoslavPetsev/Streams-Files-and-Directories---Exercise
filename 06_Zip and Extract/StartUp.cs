using System;
using System.IO.Compression;

namespace _06_Zip_and_Extract
{
    class Program
    {
        static void Main()
        {
            string picFolderPath = ".";
            string targetPath = @"..\..\..\result.zip";

            //create
            ZipFile.CreateFromDirectory(picFolderPath, targetPath);

            //extract
            ZipFile.ExtractToDirectory(targetPath, @"..\..\");
        }
    }
}
