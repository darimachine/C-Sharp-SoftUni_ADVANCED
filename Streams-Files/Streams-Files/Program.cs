using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace Streams_Files
{
    

    class Program
    {
        static void Main(string[] args)
        {




            //using StreamReader sr = new StreamReader("countries.txt");
            //using var sw = new StreamWriter("odd_countries.txt");
            //int row = 1;
            //while (!sr.EndOfStream)
            //{
            //    var line = sr.ReadLine();
            //    sw.WriteLine($"{row}. {line}");
            //    row++;
            //}
            //-----------------------------
            //using FileStream filesSTream = new FileStream("countries.txt", FileMode.OpenOrCreate);
            //var data = new byte[filesSTream.Length];


            //var bytesPerFile = (int)Math.Ceiling(filesSTream.Length / 4.00);
            //for (int i = 0; i < 4; i++)
            //{
            //    var buffer = new byte[bytesPerFile];
            //    filesSTream.Read(buffer);
            //    using FileStream writer = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate);
            //    writer.Write(buffer);
            //}
            //--------------------
            //using var sr = new StreamReader("countries.txt");
            //var data = sr.ReadToEnd().ToCharArray();
            //data[0] = '4';
            //Console.WriteLine(data);
            //var filecontent = File.ReadAllLines("countries.txt");
            //foreach (var content in filecontent)
            //{
            //    Console.WriteLine(content);
            //}
            //File.WriteAllText("myfile.txt", "Serhan");
            //var arr = new string[] { "opa", "red1", "red2" };
            //File.WriteAllLines("arr.txt",arr);

            //Directory.Move("test", "test123");
            // DirectoryGetLenght--------------------------


            var directorypath = ".";
            
            static long GetTotalLenght(string directorypath)
            {
                string[] files = Directory.GetFiles(directorypath);
                long totalSum = 0;
                foreach (var item in files)
                {
                    totalSum += new FileInfo(item).Length;
                }
                var subDirectories = Directory.GetDirectories(directorypath);
                foreach (var directory in subDirectories)
                {
                    totalSum += GetTotalLenght(directory);
                }
                return totalSum;
            }
            Console.WriteLine(GetTotalLenght(directorypath));













        }
    }
}
