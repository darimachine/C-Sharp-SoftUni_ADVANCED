using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Street_Racing
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Make: {this.Make}");
            output.AppendLine($"Model: {this.Model}");
            output.AppendLine($"License Plate: {this.LicensePlate}");
            output.AppendLine($"Horse Power: {this.HorsePower}");
            output.AppendLine($"Weight: {this.Weight}");
            return output.ToString();
        }
    }
}
