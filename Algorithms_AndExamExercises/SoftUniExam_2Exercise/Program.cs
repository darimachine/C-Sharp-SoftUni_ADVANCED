using System;
using System.Linq;

namespace SoftUniExam_2Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentrow = 0, currentcolumn =0 , touchedOponents = 0, movesMade = 0;
  
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int row = dimensions[0];
            int column = dimensions[1];
            char[,] array = new char[row, column];
            for (int i = 0; i < row; i++)
            {
                
                var symbol = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < column; j++)
                {
                    if(char.Parse(symbol[j]) == 'B')
                    {
                        currentrow = i;
                        currentcolumn = j;
                    }
                    array[i, j] =  char.Parse(symbol[j]);
                }
                    
                
            }

            string command = Console.ReadLine();
            while (command != "Finish")
            {
                if (touchedOponents == 3)
                {
                    break;
                }
                switch(command)
                {
                    case "up": 
                    {
                        currentrow--;    
                        if (IsInside(array, currentrow, currentcolumn))
                        {
                                
                                if(array[currentrow, currentcolumn] != 'O')
                                {
                                    if(array[currentrow, currentcolumn] == 'P')
                                    {
                                        touchedOponents++;
                                    }
                                    movesMade++;
                                    array[currentrow+1, currentcolumn] = '-';
                                    array[currentrow, currentcolumn] = 'B';
                                }
                                else
                                {
                                    currentrow++;
                                }
                            }
                        else
                        {
                            currentrow++;
                        }
                            break; 
                    }
                    case "down":
                    {
                        currentrow++;
                        if (IsInside(array, currentrow, currentcolumn))
                        {                      
                            if (array[currentrow, currentcolumn] != 'O')
                            {
                                if (array[currentrow, currentcolumn] == 'P')
                                {
                                    touchedOponents++;
                                }
                                movesMade++;
                                array[currentrow-1, currentcolumn] = '-';
                                array[currentrow, currentcolumn] = 'B';
                            }
                            else
                            {
                                currentrow--;
                            }
                        }
                        else
                        {
                            currentrow--;
                        }
                        break;
                    }
                    case "right":
                    {
                        currentcolumn++;
                        if (IsInside(array, currentrow, currentcolumn))
                        {
                            if (array[currentrow, currentcolumn] != 'O')
                            {
                                if (array[currentrow, currentcolumn] == 'P')
                                {
                                    touchedOponents++;
                                }
                                movesMade++;
                                array[currentrow, currentcolumn-1] = '-';
                                array[currentrow, currentcolumn] = 'B';
                            }
                            else
                            {
                                currentcolumn--;
                            }
                        }
                        else
                        {
                            currentcolumn--;
                        }
                            break;
                    }
                    case "left":
                    {
                        currentcolumn--;
                        if (IsInside(array, currentrow, currentcolumn))
                        {
                            if (array[currentrow, currentcolumn] != 'O')
                            {
                                if (array[currentrow, currentcolumn] == 'P')
                                {
                                    touchedOponents++;
                                }
                                movesMade++;
                                array[currentrow, currentcolumn+1] = '-';
                                array[currentrow, currentcolumn] = 'B';
                            }
                            else
                            {
                                currentcolumn++;
                            }
                        }
                        else
                        {
                            currentcolumn++;
                        }
                        break;
                    }
                    default: { break; }

                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOponents} Moves made: {movesMade}");

        }
        static bool IsInside(char[,] board, int row, int column)
        {
            return row >= 0 && row < board.GetLength(0) && column >= 0 && column < board.GetLength(1);
        }
    }
}
