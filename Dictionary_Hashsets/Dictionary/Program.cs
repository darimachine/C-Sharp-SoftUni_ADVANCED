using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new Dictionary<double, int>();
            for (int i = 0; i < list_of_numbers.Length; i++)
            {
                var number = double.Parse(list_of_numbers[i]);
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers[number] = 1;
                }
            }
            //--------------------------------------------------STUDENT
            int n = int.Parse(Console.ReadLine());
            var student = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ");
                if (!student.ContainsKey(line[0]))
                {
                    student[line[0]] = new List<double>();

                }
                student[line[0]].Add(double.Parse(line[1]));


            }
            foreach ((string key, List<double> value) in student)
            {
                Console.WriteLine();
                Console.Write(key + "->");
                for (int i = 0; i < value.Count; i++)
                {
                    Console.Write($"  {value[i]:F2}");
                }
                Console.Write($"avg({value.Average():F2})");


            }
            //------------------------------------SHOP
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                var line = Console.ReadLine().Split(", ");
                string shop = line[0];
                if (shop.ToLower() == "revision")
                {
                    break;
                }
                string product = line[1];
                double price = double.Parse(line[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                shops[shop][product] = price;
            }


            foreach ((var shop, var products) in shops)
            {
                Console.WriteLine($"{shop}->");

                foreach ((var product, var price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price {price:F2}");
                }

            }
            // --------------------------------------------------- Continets and Countries
            var countries = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ");
                string continent = line[0];
                string country = line[1];
                string city = line[2];
                if (!countries.ContainsKey(continent))
                {
                    countries[continent] = new Dictionary<string, List<string>>();
                }
                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent][country] = new List<string>();
                }
                countries[continent][country].Add(city);
            }
            foreach ((var continent,var countris) in countries )
            {
                Console.WriteLine($"{continent}:");
                foreach ((var country,var city) in countris)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ",city)}");
                }
            }


        }
    }
}
