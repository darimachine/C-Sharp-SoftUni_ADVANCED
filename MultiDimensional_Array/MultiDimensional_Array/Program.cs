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
            string[] dimensions = Console.ReadLine().Split(", ");
            int rows = int.Parse(dimensions[0]);
            int columns = int.Parse(dimensions[1]);
            int[,] numbers = new int[rows,columns];
            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split(", ");
                for (int col = 0; col < columns; col++)
                {
                    numbers[row, col] = int.Parse(line[col]);
                }
            }
            string[] submatrix = Console.ReadLine().Split(", ");
            int subrow= int.Parse(submatrix[0]);
            int subcol = int.Parse(submatrix[1]); 
            long maxSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;
            for (int row = 0; row < numbers.GetLength(0) -subrow+ 1; row++)
            {
                for (int col = 0; col < numbers.GetLength(1) -subcol+ 1; col++)
                {
                    var sum = 0;
                    for (int i = 0; i < subrow; i++)
                    {
                        for (int j = 0; j < subcol; j++)
                        {
                            sum= sum+numbers[row+i,col+j];
                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }
            Console.WriteLine(maxSum);
            for (int row = maxSumRow; row < maxSumRow+subrow; row++)
            {
                for (int col = maxSumCol; col < maxSumCol+subcol; col++)
                {
                    Console.Write(numbers[row,col] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}
