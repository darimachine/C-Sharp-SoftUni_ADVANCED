using System;
using System.Collections.Generic;
using System.Linq;
namespace Sets_Dictionaries_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // WARDROBE -------------------------
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" -> ");
                var color = line[0];
                string[] dresses = line[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                foreach (var dress in dresses)
                {

                    if (wardrobe[color].ContainsKey(dress))
                    {
                        wardrobe[color][dress]++;
                    }
                    else
                    {
                        wardrobe[color][dress] = 1;
                    }

                }


            }
            string[] color_dress = Console.ReadLine().Split(" ");

            //wardrobe.OrderBy(x => x.Key == color_dress[0]);
            foreach (var (color, dresses) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (dress, count) in dresses)
                {
                    if (color == color_dress[0] && dress == color_dress[1])
                    {
                        Console.WriteLine($"* {dress} - {wardrobe[color][dress]} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {dress} - {wardrobe[color][dress]}");
                }
            }
            // V-LOGGER --------------------------------------------------------
            var vloggers = new Dictionary<string, Vlogger>();

            while (true)
            {
                var line = Console.ReadLine().Split(" ");
                var name = line[0];
                if (name == "Statistics")
                {
                    break;
                }
                var action = line[1];

                if (action == "joined")
                {
                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers[name] = new Vlogger();



                    }


                }
                else if (action == "followed")
                {
                    var second_acc = line[2];
                    if (vloggers.ContainsKey(name) && vloggers.ContainsKey(second_acc) && name != second_acc)
                    {
                        vloggers[name].Following.Add(second_acc);
                        vloggers[second_acc].Followers.Add(name);




                    }


                }

            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count} vloggers in its logs.");

            var sortedVloggers = vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count);
            int count = 1;
            foreach (var (vloggername, value) in sortedVloggers)
            {

                Console.WriteLine($"{count}. {vloggername} : {value.Followers.Count} followers, {value.Following.Count} following");

                if (count == 1)
                {
                    foreach (var followers in value.Followers.OrderBy(x => x))
                    {

                        Console.WriteLine($"*  {followers}");


                    }
                }
                count++;


            }


            // RANKING ZADACHA 8 ----------------------------------------------
            var contests = new Dictionary<string, string>();
            var participants = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                var line = Console.ReadLine().Split(":");
                string contest_name = line[0];
                if (contest_name == "end of contests")
                {
                    break;
                }
                string password = line[1];
                if (!contests.ContainsKey(contest_name))
                {
                    contests[contest_name] = password;

                }
               


            }
            while (true)
            {
                var line = Console.ReadLine().Split("=>");
                string contest_name = line[0];
                if (contest_name == "end of submissions")
                {
                    break;
                }
                string password = line[1];
                string name = line[2];
                int point = int.Parse(line[3]);
                if (contests.ContainsKey(contest_name) && contests[contest_name] == password)
                {
                    if (!participants.ContainsKey(name))
                    {
                        participants[name] = new Dictionary<string, int>();

                    }
                    if (!participants[name].ContainsKey(contest_name))
                    {
                        participants[name][contest_name]=0;
                    }
                    if (participants[name][contest_name] < point)
                    {
                        participants[name][contest_name] = point;
                    }
                }
                

            }
            int topSum = 0;
            int Sum = 0;
            string username = " ";
            //var topParticipant = participants.Values.OrderByDescending(x=>x.Values)
            foreach (var (user, contest) in participants)
            {
                foreach (var (contest_names, points) in contest)
                {
                    topSum += points;
                  
                }
                if (topSum > Sum)
                {
                    Sum = topSum;
                    username = user;
                    topSum = 0;
                }
                

            }
            Console.WriteLine($"Best candidate is {username} with total {Sum} points.");
            Console.WriteLine("Ranking: ");
            foreach (var (user, contest) in participants.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{user}");
                foreach (var (contest_name,contest_point) in contest.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest_name} -> {contest_point}");
                }
            }


        }
    }
}
