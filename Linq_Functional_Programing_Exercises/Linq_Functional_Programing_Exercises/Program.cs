using System;
using System.Collections.Generic;
using System.Linq;
namespace Linq_Functional_Programing_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //String with Func-----------------------------------
            Func<int, string> isEvenOrOdd = number =>
             {
                 if (number % 2 == 0)
                 {
                     return "even";
                 }
                 return "odd";
             };
            Action<string[]> action = name => name.ToList().ForEach(x => Console.WriteLine($"Sir {x}"));

            var line = Console.ReadLine().Split(" ");
            action(line);
            //Smallest Number -----------------------------------

            var numbers = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(Min(numbers));
            Console.WriteLine(Min2(numbers));
            // EVEN ODD NUMBER PREDICATE------------------------------------
            Action<IEnumerable<int>> PrintNumbers = x => Console.WriteLine(string.Join(" ", x));
            var range = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var numbers = Enumerable.Range(range[0], range[1] - range[0] + 1).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
            var command = Console.ReadLine();
            Predicate<int> output = x => true;

            if (command == "odd")
            {
                output = x => x % 2 != 0;

            }
            else if (command == "even")
            {
                output = x => x % 2 == 0;
            }
            PrintNumbers(numbers.Where(x => output(x)));
            //COMMANDS WITH ADD SUBTRACT PRINT AND MORE------------------
            Func<int, int> add = x => x + 1;
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        {
                            numbers = numbers.Select(add).ToArray();
                            break;
                        }
                    case "subtract":
                        {
                            numbers = numbers.Select(x => x - 1).ToArray();
                            break;
                        }
                    case "multiply":
                        {
                            numbers = numbers.Select(x => x * 2).ToArray();
                            break;
                        }
                    case "print":
                        {
                            Console.WriteLine(string.Join(" ", numbers));
                            break;
                        }
                    default:

                        break;
                }
                command = Console.ReadLine();

            }
            //REVERSE and Exclude------------------------
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var divisiblenumber = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = n => n % divisiblenumber == 0;
            var result = numbers.Where(x => !isDivisible(x)).Reverse().ToArray();
            Console.WriteLine(string.Join(" ", result));
            // Predicate For Names
            int lenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ");


            var result = names.Where(x => x.Length <= lenght).ToArray();
            Console.WriteLine(string.Join("\n", result));
            // Custom comparator
            //List of Predicates---------------------------
            int range_number = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(1, range_number).ToArray();
            var divided_number = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Func<int[], int[], List<int>> predicates = (numbers, divided_numbers) =>
              {
                  var result = new List<int>();
                  foreach (var number in numbers)
                  {
                      bool isDivisible = true;
                      foreach (var divide in divided_number)
                      {
                          if (!(number % divide == 0))
                          {
                              isDivisible = false;
                              break;
                          }


                      }
                      if (isDivisible)
                      {
                          result.Add(number);
                      }
                  }
                  return result;

              };
            Console.WriteLine(string.Join(" ", predicates(numbers, divided_number)));
            // Party Slojna -----------------------------

            List<string> names = Console.ReadLine().Split(" ").ToList();
            string command = Console.ReadLine().ToLower();
            while (command != "party!")
            {
                string[] commandInfo = command.Split(" ");
                var action = commandInfo[0].ToLower();
                Predicate<string> predicate = GetPredicate(commandInfo[1], commandInfo[2]);
                if (action == "remove")
                {
                    names.RemoveAll(predicate);
                }
                else if (action == "double")
                {
                    List<string> doubledNames = names.FindAll(predicate);
                    if (doubledNames.Any())
                    {
                        int index = names.FindIndex(predicate);
                        names.InsertRange(index, doubledNames);
                    }
                }

                command = Console.ReadLine().ToLower();
            }
            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Noby is going to the party");
            }
            // Party Posledna DICT ------------------------------
            List<string> names = Console.ReadLine().Split(" ").ToList();
            var dictionary = new Dictionary<string, Predicate<string>>();
            string command = Console.ReadLine();
            while (command != "Print")
            {
                var commandArgs = command.Split(";");
                string action = commandArgs[0];
                string predicateAction = commandArgs[1];
                string value = commandArgs[2];
                string key = predicateAction + "_" + value;


                if (action == "Add filter")
                {

                    Predicate<string> predicate = GetPredicate(predicateAction, value);
                    dictionary[key] = predicate;
                }
                else
                {
                    dictionary.Remove(key);
                }
                command = Console.ReadLine();
            }
            foreach (var (key, predicate) in dictionary)
            {
                names.RemoveAll(predicate);
            }
            Console.WriteLine(string.Join(" ", names));
            //TriFunction --------------- 
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ").ToArray();
            Func<string, int, bool> logic = (name, number) =>
              {
                  var new_name = name.ToCharArray();
                  int sum = 0;
                  foreach (var item in new_name)
                  {
                      sum += item;
                  }
                  if (sum >= number)
                  {
                      return true;
                  }
                  return false;
              };
            var result = names.FirstOrDefault(x => logic(x, n));
            Console.WriteLine(result);
        }

        private static Predicate<string> GetPredicate(string commandInfo,string param)
        {
            if (commandInfo.ToLower() == "starts with")
            {
                return x => x.StartsWith(param);
            }
            if (commandInfo.ToLower() == "endsswith")
            {
                return x => x.EndsWith(param);
            }
            if (commandInfo.ToLower() == "contains")
            {
                return x => x.Contains(param);
            }
            int lenght = int.Parse(param);
            return x => x.Length == lenght;
        }

        public static Func<int[], int> Min = x => x.Min();
        public static int Min2(int[] numbers)
        {
            return numbers.Min();
        }
    }
}
