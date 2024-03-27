using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ovning5
{
    public class GarageHandler
    {
        private IGarage<Vehicle> garage;

        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            garage.ParkVehicle(vehicle);
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            return garage.RemoveVehicle(registrationNumber);
        }

        public IEnumerable<Vehicle> GetParkedVehicles()
        {
            return garage.GetParkedVehicles();
        }


        public void ListTypesAndCounts()
        {
            var typeCounts = new Dictionary<string, int>();

            foreach (var vehicle in garage.GetParkedVehicles())
            {
                string vehicleType = vehicle.GetType().Name;
                if (typeCounts.ContainsKey(vehicleType))
                {
                    typeCounts[vehicleType]++;
                }
                else
                {
                    typeCounts[vehicleType] = 1;
                }
            }

            Console.WriteLine("Types of vehicles and their counts in the garage:");
            foreach (var kvp in typeCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        public Vehicle FindVehicleByRegistrationNumber(string registrationNumber)
        {
            return garage.FindVehicleByRegistrationNumber(registrationNumber);
        }

        // Method to search for vehicles based on a predicate
        public IEnumerable<Vehicle> Search(Func<Vehicle, bool> predicate)
        {
            return garage.Search(predicate);
        }

        

        
    }
}
