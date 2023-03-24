using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Exam_1_Exercise
{
    class Race
    {
        
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }
        public int Count { 
            get
            {
                return Participants.Count;
            }
            private set 
            {
                Count = value; 
            } }
        public void Add(Car car)
        {
            if (Capacity >= Count)
            {
                if (car.HorsePower <= MaxHorsePower)
                {
                    if(!Participants.Any(x => x.LicensePlate == car.LicensePlate))
                    {
                        Participants.Add(car);
                    }
                }
            }
        }
        public bool Remove(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car != null)
            {
                Participants.Remove(car);
                return true;
            }
            return false;

        }
        public Car FindParticipant(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return car;
        }
        public Car GetMostPowerfulCar()
        {
            if (Count <= 0)
            {
                return null;
            }
            Car car= Participants.FirstOrDefault(x=>x.HorsePower==Participants.Max(x=>x.HorsePower));
            return car;
        }
        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Race: {this.Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in Participants)
            {
                output.AppendLine($"Make: {item.Make}");
                output.AppendLine($"Model: {item.Model}");
                output.AppendLine($"License Plate: {item.LicensePlate}");
                output.AppendLine($"Horse Power: {item.HorsePower}");
                output.AppendLine($"Horse Power: {item.Weight}");
            }
            return output.ToString();

        }
    }
}
