using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_1_Exercise
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var textiles_queue = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var medicaments_stack = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int patch = 30;
            int bandage = 40;
            int medkit = 100;
            Dictionary<string, int> items = new Dictionary<string, int>();
            items["Patch"] = 0;
            items["Bandage"] = 0;
            items["MedKit"] = 0;
            while(textiles_queue.Count!=0 && medicaments_stack.Count != 0)
            {
                int sum = textiles_queue.Peek() + medicaments_stack.Peek();
                if (sum >= medkit)
                {
                    int difference = sum - medkit;
                    textiles_queue.Dequeue();
                    medicaments_stack.Pop();
                    if (difference != 0)
                    {
                        if (medicaments_stack.Count != 0)
                        {
                            medicaments_stack.Push(medicaments_stack.Pop() + difference);
                        }
                        else
                        {
                            medicaments_stack.Push(difference);
                        }
                    }
                    items["MedKit"]++;
                }
                else if (sum == bandage)
                {
                    textiles_queue.Dequeue();
                    medicaments_stack.Pop();
                    items["Bandage"]++;
                }
                else if (sum == patch)
                {
                    textiles_queue.Dequeue();
                    medicaments_stack.Pop();
                    items["Patch"]++;
                }
                else
                {
                    textiles_queue.Dequeue();
                    medicaments_stack.Push(medicaments_stack.Pop() + 10);
                    
                }



            }
            items = items.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            if(textiles_queue.Count == 0 && medicaments_stack.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
                foreach (var (key, value) in items)
                {
                    if (value != 0)
                    {
                        Console.WriteLine($"{key} - {value}");
                    }
                    
                }
            }
            else if (textiles_queue.Count == 0)
            {
                Console.WriteLine("Textiles are empty.");
                foreach (var (key, value) in items)
                {
                    if (value != 0)
                    {
                        Console.WriteLine($"{key} - {value}");
                    }
                }
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments_stack)}");
            }
            else if (medicaments_stack.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
                foreach (var (key, value) in items)
                {
                    if (value != 0)
                    {
                        Console.WriteLine($"{key} - {value}");
                    }
                }
                Console.WriteLine($"Textiles left: {string.Join(", ",textiles_queue)}");
            }
           
        }
                   
           
    }
            
        
}

