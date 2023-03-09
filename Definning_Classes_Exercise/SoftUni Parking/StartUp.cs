using System;
using System.Collections.Generic;
using System.Linq;
namespace SoftUniParking
{
    class Car {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }
        public Car(string make, string model, int horsepower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsepower;
            this.RegistrationNumber = registrationNumber;
    
        }
        public override string ToString()
        {
            return $"Make : {this.Make}\nModel: {this.Model}\nHorsePower: {this.HorsePower}\nRegistrationNumber: {this.RegistrationNumber}";
        }
    }
    class Parking
    {
        public List<Car> Cars { get; set; }
        private int capacity;
        public int Count { get { return Cars.Count; }}
        
        public Parking(int capacity)
        {
            Cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            foreach (var car_item in this.Cars)
            {
                if (car_item.RegistrationNumber == car.RegistrationNumber)
                {
                    return "Car with that registration number, already exists!";
                }
            }
            if (Cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }
            Cars.Add(car);
           
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            foreach (var car_item in this.Cars)
            {
                if (car_item.RegistrationNumber == registrationNumber)
                {
                    this.Cars.Remove(car_item);
                    
                    return $"Successfully removed {registrationNumber}";
                }
            }
            return "Car with that registration number, doesn't exist!";

        }
        public Car GetCar(string registrationNumber)
        {
            Car car=new Car("","",0,"");
            foreach (var car_item in this.Cars)
            {
                if (car_item.RegistrationNumber == registrationNumber)
                {
                    
                    return car_item;
                }
            }
            return car;
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var car in Cars)
            {
                if (RegistrationNumbers.Contains(car.RegistrationNumber))
                {
                    this.Cars.Remove(car);
                }
            }
        }
        


    }

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());
            //Make: Skoda
            //Model: Fabia
            //HorsePower: 65
            //RegistrationNumber: CC1856BG

            var parking = new Parking(5);
            Console.WriteLine(parking.AddCar(car));
            //Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(car));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Make: Audi
            //Model: A3
            //HorsePower: 110
            //RegistrationNumber: EB8787MN

            Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Successfullyremoved EB8787MN

            Console.WriteLine(parking.Count); //1


        }
    }
}
