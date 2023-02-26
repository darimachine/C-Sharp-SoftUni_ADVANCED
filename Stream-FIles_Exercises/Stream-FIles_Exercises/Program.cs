using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Stream_FIles_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //Count Sympols, Punc
            var file = File.ReadAllLines("output.txt");
            for (int i = 0; i < file.Length; i++)
            {
                int letterCount = file[i].Count(symbol => char.IsLetter(symbol));
                int punctoations = file[i].Count(punc => char.IsPunctuation(punc));
                //File.AppendText("output2.txt");
                File.AppendAllText("output2.txt", $"Line {i + 1}: {file[i]} ({letterCount}) ({punctoations})\n");

            }
            // - Reading and Writing File
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string file = File.ReadAllText("output.txt");
            Console.WriteLine(file);
            var words_txt = File.ReadAllLines("words.txt");

            foreach (var item in words_txt)
            {
                if (!wordsCount.ContainsKey(item))
                {
                    wordsCount[item] = 0;
                }
            }
            foreach (var line in file)
            {
                foreach (var word in wordsCount)
                {
                    //if (line.Contains(word.Key,StringComparison.OrdinalIgnoreCase))
                    {
                        wordsCount[word.Key]++;
                    }
                }
            }
            foreach (var (key, value) in wordsCount.OrderByDescending(x => x.Value))
            {
                string result = $"{key} - {value}\n";
                File.AppendAllText("actualResult.txt", result);
            }


        }
        


    }
}
