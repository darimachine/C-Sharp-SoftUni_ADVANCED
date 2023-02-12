using System;
namespace MultiDimensional_Array
{
    class Program
    {
        static void Main(string[] args)
        {

            //char[,] board = new char[3, 4]
            //{         
            //        {'x','o','x','e' },
            //        {' ','x','o','e' },
            //        { ' ','x','o','e'},
            //};
            //Console.WriteLine(board.Rank);
            //int[,] table = new int[3, 5];
            //for (int row = 0; row < 3; row++)
            //{
            //    for (int col = 0; col < 5; col++)
            //    {
            //        table[row, col] = row * col;
            //    }
            //}
            ////foreach (var item in table)
            ////{
            ////    Console.WriteLine(item);
            ////}
            //for (int row = 0; row < board.GetLength(0); row++)
            //{
            //    for (int col = 0; col < board.GetLength(1); col++)
            //    {
            //        Console.Write(board[row,col]+ " "); 
            //    }
            //    Console.WriteLine();
            //}
            int[,] numbers = new int[3, 6];
            for (int row = 0; row < 3; row++)
            {
                string[] line = Console.ReadLine().Split(", ");
                for (int col = 0; col < 6; col++)
                {
                    numbers[row, col] = int.Parse(line[col]);
                }
            }
            long maxSum = long.MinValue;
            for (int row = 0; row < numbers.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < numbers.GetLength(1) - 1; col++)
                {
                    var sum = numbers[row, col] + numbers[row, col + 1] +
                    numbers[row + 1, col] + numbers[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine(maxSum);


        }
    }
}
