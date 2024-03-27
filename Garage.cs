using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        void ParkVehicle(T vehicle);
        bool RemoveVehicle(string registrationNumber);
        void ListTypesAndCounts();
        IEnumerable<T> GetParkedVehicles();
        T FindVehicleByRegistrationNumber(string registrationNumber);
        IEnumerable<T> Search(Func<T, bool> predicate);
       
    }
    public class Garage<T> : IGarage<T> where T : Vehicle
    {
        private T[] vehicles;
        private int count = 0;
        public int capacity { get; private set; }
        public int Count => count;

        // Constructor with capacity
        public Garage(int capacity)
        {
          
            this.capacity = capacity;
            vehicles = new T[capacity];
        }
        // Method to set capacity
        public void SetCapacity(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be a positive integer.");
            }
          
        }

        // Method to populate garage with vehicles
        public void Populate(IEnumerable<T> vehiclesToAdd)
        {
            foreach (var vehicle in vehiclesToAdd)
            {
                ParkVehicle(vehicle);
            }
        }


        public void ParkVehicle(T vehicle)
        {
            if (count >= capacity)
            {
                throw new InvalidOperationException("Garage is full.");
            }

            
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    count++;
                    return; // Exit the method once the vehicle is parked
                }
            }
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Array.Clear(vehicles, i, 1); // Reset the element to default value
                    Console.WriteLine($"Vehicle with registration number {registrationNumber} removed from the garage.");
                    count--; // Decrement count
                    return true;
                }
            }
            Console.WriteLine($"Vehicle with registration number {registrationNumber} not found in the garage.");
            return false;
        }

       
       
          public void ListParkedVehicles()
        {
            Console.WriteLine("List of parked vehicles:");
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}, Color: {vehicle.Color}, Number of Wheels: {vehicle.NumberOfWheels}");
                }
            }
        }

        public void PrintAllVehicles()
        {
            Console.WriteLine("Details of all parked vehicles:");
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }
        }



        public void ListTypesAndCounts()
        {
            var typeCounts = new Dictionary<Type, int>();
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Type type = vehicle.GetType();
                    if (typeCounts.ContainsKey(type))
                    {
                        typeCounts[type]++;
                    }
                    else
                    {
                        typeCounts[type] = 1;
                    }
                }
            }
            Console.WriteLine("Types of vehicles and their counts in the garage:");
            foreach (var kvp in typeCounts)
            {
                Console.WriteLine($"{kvp.Key.Name}: {kvp.Value}");
            }
        }

        // find vihicle by registration number
        public T FindVehicleByRegistrationNumber(string registrationNumber)
        {
            foreach (T vehicle in vehicles)
            {
                if (vehicle != null && string.Equals(vehicle.RegistrationNumber, registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return vehicle;
                }
            }
            return null;
        }



        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            return vehicles.Take(count).Where(predicate);
        }

        public IEnumerable<T> GetParkedVehicles()
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)vehicles).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
