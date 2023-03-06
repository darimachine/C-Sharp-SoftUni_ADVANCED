using System;
using System.Linq;
namespace Defining_classes
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tire { get; set; }
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            Year = 2025;
            FuelConsumption = 10;
            FuelQuantity = 200;
        }
        public Car(string make, string model)
        {
            this.Make = make;
            this.Model = model;
        }
        public Car(string make, string model,int year) : this(make,model)
        {
            
            this.Year = year;
            
        }
        public Car(string make, string model, int year,double fuelquantity,double consumption) : this(make, model,year)
        {

            this.FuelQuantity = fuelquantity;
            this.FuelConsumption = consumption;

        }
        public Car(string make, string model, int year, double fuelquantity, double consumption, Engine engine,Tire[] tires) : this(make, model, year,fuelquantity,consumption)
        {
            this.Engine = engine;
            this.Tire = tires;
        }
        public string WhoAmI()
        {
            return $"{Make} {Model} ({Year})";
        }
        public void Drive(double distance)
        {
            var consumption = distance * (FuelConsumption / 100);
            if (consumption <= FuelQuantity)
            {
                FuelQuantity -= consumption;
            }
            else
            {
                Console.WriteLine($"Cannot drive{distance:f2} km");
            }
        }


    }
    class Engine
    {
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
        public Engine(int horsePower,double cubicCapacity)   
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

    }
    class Tire
    {
        public int Year { get; set; }
        public double Pressure { get; set; }
        public Tire(int year,double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        
    }
    enum Season
    {
        Spring=1,Summer=2,Autumn=3,Winter=4
    }

    class Program
    {
        static void Main(string[] args)
        {
            var masiv = new int[]{ 8, 7, 6, 5, 3 };
            int min =masiv.Aggregate((x,y)=>Math.Min(x,y));
            Console.WriteLine(min);
            Season season = Season.Summer;
            PrintSeasonSong(season);
            Console.WriteLine((int)season);
            
            Engine engine = new Engine(125, 1.8);
            Tire[] tires = new Tire[]
            { 
                new Tire(2018, 20), 
                new Tire(2019, 26), 
                new Tire(2021, 23), 
                new Tire(2022, 10) 
            };
            Car car = new Car("Audi","A7",2004,80,15,engine,tires);
            car.Year = 2017;
            car.Make = "Audi";
            car.Model = "A7";
            car.FuelQuantity = 80;
            car.FuelConsumption = 15;
            Console.WriteLine(car.WhoAmI());
            car.Drive(100);
            car.Drive(100);
            car.Drive(100);
            car.Drive(100);
            car.Drive(100);
            car.Drive(100);
            car.Drive(100);
            car.Drive(100);

        }
        static void PrintSeasonSong( Season season)
        {
            if (season == Season.Summer)
            {
                Console.WriteLine("All summer long");
            }
        }
    }
}
