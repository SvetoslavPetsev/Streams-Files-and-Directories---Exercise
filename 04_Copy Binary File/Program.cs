using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _04_Copy_Binary_File
{
    class Program
    {
        static void Main()
        {
            string picPath = "copyMe.png";
            string picCopypath = "copyMe-copy.png";

            using (FileStream streamReader = new FileStream(picPath, FileMode.Open))
            {
                using (FileStream streamWriter = new FileStream(picCopypath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] byteArray = new byte[4096];
                        int size = streamReader.Read(byteArray, 0, byteArray.Length);
                        if (size == 0)
                        {
                            break;
                        }
                        streamWriter.Write(byteArray, 0, size);
                    }
                }
            }
        }
    }
}
