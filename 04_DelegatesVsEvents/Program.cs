using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SmartList
{
    class Vehicle
    {
        public string Name { get; set; }
        public double Weight { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SmartList<Vehicle> vehicles = new SmartList<Vehicle>("import.txt", Encoding.Default, VehicleCompare, Import, Export);
            vehicles.AddElement(new Vehicle()
            {
                Name = "airplane",
                Weight = 40000
            });
            vehicles.Export("export.txt", Encoding.Default);
        }

        //externally attached import/export/comparing implementation

        static Vehicle Import(string line)
        {
            return new Vehicle()
            {
                Name = line.Split('#')[0],
                Weight = double.Parse(line.Split('#')[1])
            };
        }

        static string Export(Vehicle v)
        {
            return v.Name + "#" + v.Weight;
        }

        static int VehicleCompare(Vehicle v1, Vehicle v2)
        {
            return v1.Weight.CompareTo(v2.Weight);
        }
    }
}
