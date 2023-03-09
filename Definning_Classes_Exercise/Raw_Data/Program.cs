using System;
using System.Collections.Generic;
using System.Linq;

namespace Raw_Data
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tire { get; set; }
        public Car(string model,Engine engine,Cargo cargo,List<Tire> tire)
        {
            Tire = new List<Tire>();
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tire;
        }

    }
    class Engine
    {
        public Engine(int speed,int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }
    }
    class Cargo
    {
        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
    class Tire
    {
        public Tire(int age, double presure)
        {
            this.Age = age;
            this.Presure = presure;
        }
        public int Age { get; set; }
        public double Presure { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int NumberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < NumberOfCars; i++)
            {
                var line_car = Console.ReadLine().Split(" ");
                var model = line_car[0];
                var engineSpeed = int.Parse(line_car[1]);
                var enginePower = int.Parse(line_car[2]);
                var cargoWeight = int.Parse(line_car[3]);
                var cargoType = line_car[4];

                List<Tire> tires = new List<Tire>();
                for (int tireindex = 5; tireindex <= 12; tireindex+=2)
                {
                    var tire1Pressure = double.Parse(line_car[tireindex]);
                    var tire1Age = int.Parse(line_car[tireindex+1]);
                    Tire tire = new Tire(tire1Age, tire1Pressure);
                    tires.Add(tire);
                }
                
                //var tire2Pressure = double.Parse(line_car[7]);
                //var tire2Age = int.Parse(line_car[8]);
                //var tire3Pressure = double.Parse(line_car[9]);
                //var tire3Age = int.Parse(line_car[10]);
                //var tire4Pressure = double.Parse(line_car[11]);
                //var tire4Age = int.Parse(line_car[12]);
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
                
            }
            var command = Console.ReadLine();
            if (command == "fragile")
            {
                List<Car> fragileCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tire.Any(x=>x.Presure<1)).ToList();
                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                List<Car> flammableCars = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power>250).ToList();
                foreach (var car in flammableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }

            

        }
    }
}
