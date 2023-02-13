using System;
using System.Collections;
using System.Collections.Generic;

namespace Jagged_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 exercise
            int lenght = int.Parse(Console.ReadLine());
            int[][] arr = new int[lenght][];
            for (int i = 0; i < lenght; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                arr[i] = new int[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    arr[i][j] = int.Parse(line[j]);
                }
            }

            while (true)
            {
                var line = Console.ReadLine();
                var commandParts = line.Split(" ");
                var commandName = commandParts[0].ToLower();
                if (commandName == "end")
                {
                    break;
                }
                var arrayIndex = int.Parse(commandParts[1]);
                var arrayElement = int.Parse(commandParts[2]);
                var value = int.Parse(commandParts[3]);
                if (arrayIndex < 0 || arrayIndex >= arr.Length || arrayElement < 0 || arrayElement >= arr[arrayIndex].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                else if (commandName == "add")
                {
                    arr[arrayIndex][arrayElement] += value;
                }
                else if (commandName == "subtract")
                {
                    arr[arrayIndex][arrayElement] -= value;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(String.Join(" ", arr[i]));
            }
            //Pascal Triangle Moy Variant
            int lenght = int.Parse(Console.ReadLine());
            int[][] arr = new int[lenght][];
            for (int i = 0; i < lenght; i++)
            {
               
                arr[i] = new int[i+1];
                for (int j = 0; j <= i; j++)
                {

                    
                    if (j > 0 && j<i)
                    {
                        arr[i][j] = arr[i - 1][j-1] + arr[i - 1][j];
                    }
                    else
                    {
                        arr[i][j] = 1;
                    }
                    
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                //for (int k = 0; k < arr.Length - i; k++)
                //{
                //    Console.Write(" ");
                //}
                for (int j = 0; j < arr[i].Length; j++)
                {
                    
                        Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            //Pascal Triangle 2-ri variant Best Variant
            int n = int.Parse(Console.ReadLine());
            int[][] pascal = new int[n][];
            for (int i = 0; i < n; i++)
            {

                pascal[i] = new int[i + 1];
                pascal[i][0] = 1;
                pascal[i][pascal[i].Length - 1] = 1;
                for (int j = 0; j <= i; j++)
                {
                    pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", pascal[i]));
            }
        }
    }
}
