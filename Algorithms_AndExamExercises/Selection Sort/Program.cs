using System;
using System.Linq;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = new int[] { 3, 2, 12, -50, 1 };
            BubbleSort(number);
            Console.WriteLine(string.Join(" ",number));

            
        }

        private static void SelectionSort(int[] number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                int index = i;
                for (int j = i+1; j < number.Length; j++)
                {
                    if (number[j] < number[index])
                    {
                        index = j;
                    }
                }
                (number[i], number[index]) = (number[index], number[i]);
            }         
        }
        private static void BubbleSort(int [] numbers)
        {
            for (int i = 0; i < numbers.Length-1; i++)
            {
                for (int j = 0; j < numbers.Length-i-1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        /*
                         int temp = numbers[j];
                         numbers[j] = numbers[j+1];
                         numbers[j+1] = temp
                        */ 
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    }
                }
            }
        }
    }
}
