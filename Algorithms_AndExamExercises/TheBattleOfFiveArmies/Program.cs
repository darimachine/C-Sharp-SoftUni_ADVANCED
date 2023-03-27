using System;
using System.Linq;

namespace TheBattleOfFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            bool armyDefeated = false;
            int armyArmor = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());
            char[][] middleWord = new char[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                var chars = Console.ReadLine().ToCharArray();
                middleWord[i] =chars;
                
            }
            int heroRow = 0;
            int heroCol = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < middleWord[i].Length; j++)
                {
                    if (middleWord[i][j] == 'A')
                    {
                        heroRow = i;
                        heroCol = j;
                        break;
                    }
                }
            }           
            while (true)
            {
                if (armyDefeated)
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                    break;
                }
                if (armyArmor <= 0)
                {
                    Console.WriteLine($"The army was defeated at {heroRow};{heroCol}.");
                    middleWord[heroRow][heroCol] = 'X';
                    break;
                }
                var commandLine = Console.ReadLine().Split(" ");
                var command = commandLine[0];
                var rowOrc = int.Parse(commandLine[1]);
                var colOrc = int.Parse(commandLine[2]);
                middleWord[rowOrc][colOrc] = 'O';
                middleWord[heroRow][heroCol] = '-';
                switch (command)
                { 
                    case "up":
                    {
                            armyArmor--;
                            if (IsInside(middleWord, heroRow - 1, heroCol))
                            {              
                                heroRow--;
                            }
                            goto default;
                        }
                    case "down":
                    {
                            armyArmor--;
                            if (IsInside(middleWord, heroRow + 1, heroCol))
                            {  
                                heroRow++;
                            }


                            goto default;
                        }
                    case "left":
                    {
                            armyArmor--;
                            if (IsInside(middleWord, heroRow, heroCol-1))
                            {
                                heroCol--;
                            }

                            goto default;
                           
                    }
                    case "right":
                    {
                            armyArmor--;
                            if (IsInside(middleWord, heroRow, heroCol + 1))
                            {
                                heroCol++;
                            }
                            goto default;
                            
                    }
                    default:
                        {
                            if (middleWord[heroRow][heroCol] == 'M')
                            {
                                armyDefeated = true;
                                middleWord[heroRow][heroCol] = '-';
                                break;
                            }
                            else if (middleWord[heroRow][heroCol] == 'O')
                            {
                                armyArmor=armyArmor-2;
                                
                            }
                            middleWord[heroRow][heroCol] = 'A';
                            break;
                        }
                }
            }
            for (int i = 0; i < numberOfRows; i++)
            {
                Console.WriteLine(new string(middleWord[i]));
            }

        }
        static bool IsInside(char[][] field, int row,  int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field[row].Length;
        }
    }
}
