using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;
using System.Text.RegularExpressions;

namespace Ovning5
{
    public interface IUI
    {
        string ReadInput();
        void WriteOutput(string message);
    }

    public class ConsoleUI : IUI
    {
        private GarageHandler garageHandler;

        public ConsoleUI(int capacity)
        {
            garageHandler = new GarageHandler(capacity);
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                WriteOutput("1. Park Vehicle");
                WriteOutput("2. Remove Vehicle");
                WriteOutput("3. List Parked Vehicles");
                WriteOutput("4. List Vehicle Types and Counts");
                WriteOutput("5. Find Vehicle by Registration Number");
                WriteOutput("6. Search Vehicles");
                WriteOutput("7. Exit");
                WriteOutput("Enter your choice: ");
                string choice = ReadInput();

                switch (choice)
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        RemoveVehicle();
                        break;
                    case "3":
                        ListParkedVehicles();
                        break;
                    case "4":
                        FindVehicleByRegistrationNumber();
                        break;
                    case "5":
                        SearchVehicles();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        WriteOutput("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ParkVehicle()
        {
            int wheels;
            string color;

            WriteOutput("Enter registration number: ");
            string regNumber = ReadInput();
            
            bool validColor = false;
            do
            {
                WriteOutput("Enter color: ");
                color = ReadInput();
                if (!Regex.IsMatch(color, @"^[a-zA-Z]+$"))
                {
                    WriteOutput("Invalid input. Please enter a valid color (letters only).");
                }
                else
                {
                    validColor = true;
                }
            } while (!validColor);

            bool validWheels = false;
            do
            {
                WriteOutput("Enter number of wheels: ");
                string input = ReadInput();
                if (!int.TryParse(input, out wheels))
                {
                    WriteOutput("Invalid input. Please enter a valid integer for number of wheels.");
                }
                else
                {
                    validWheels = true;
                }
            } while (!validWheels);

            Vehicle vehicle = new Vehicle(regNumber, color, wheels);
            garageHandler.ParkVehicle(vehicle);
        }

        private void RemoveVehicle()
        {
            WriteOutput("Enter registration number of vehicle to remove: ");
            string regNumber = ReadInput();
            garageHandler.RemoveVehicle(regNumber);
        }

        private void ListParkedVehicles()
        {
            Console.WriteLine("List of parked vehicles:");
            var parkedVehicles = garageHandler.GetParkedVehicles(); 
            foreach (var vehicle in parkedVehicles)
            {
                Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}, Color: {vehicle.Color}, Number of Wheels: {vehicle.NumberOfWheels}");
            }
        }

       
        private void ListTypesAndCounts()
        {
            garageHandler.ListTypesAndCounts();
        }

        private void FindVehicleByRegistrationNumber()
        {
            WriteOutput("Enter registration number of vehicle to find: ");
            string regNumber = ReadInput();
            var vehicle = garageHandler.FindVehicleByRegistrationNumber(regNumber);
            if (vehicle != null)
            {
                WriteOutput($"Vehicle found - Registration Number: {vehicle.RegistrationNumber}, Color: {vehicle.Color}, Number of Wheels: {vehicle.NumberOfWheels}");
            }
            else
            {
                WriteOutput($"Vehicle with registration number {regNumber} not found.");
            }
        }

        public void CreateMotorcycle()
        {
            Console.WriteLine("Enter registration number: ");
            string regNumber = Console.ReadLine()!;

            Console.WriteLine("Enter color: ");
            string color = Console.ReadLine()!;

            Console.WriteLine("Enter number of wheels (2, 3, or 4): ");
            int numberOfWheels;
            while (!int.TryParse(Console.ReadLine(), out numberOfWheels) || numberOfWheels < 2 || numberOfWheels > 4)
            {
                Console.WriteLine("Invalid input. A motorcycle must have 2, 3, or 4 wheels. Please enter a valid number: ");
            }

            Console.WriteLine("Enter cylinder type: ");
            string cylinder = Console.ReadLine()!;

            Motorcycle motorcycle = new Motorcycle(regNumber, color, numberOfWheels, cylinder);
            AddVehicle(motorcycle);
            Console.WriteLine("Motorcycle added successfully.");
        }

        private void AddVehicle(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        private void SearchVehicles()
        {
            WriteOutput("Enter search criteria (e.g., number of wheels, color, RegNumber): ");
            string criteria = ReadInput();

            // Validate search criteria
            if (string.IsNullOrWhiteSpace(criteria))
            {
                WriteOutput("Invalid search criteria. Please enter a valid value.");
                return;
            }

            // Perform search only if the criteria is not empty
            foreach (var vehicle in garageHandler.Search(vehicle => vehicle.Color.Equals(criteria, StringComparison.OrdinalIgnoreCase) || vehicle.NumberOfWheels.ToString().Equals(criteria)))
            {
                WriteOutput($"Registration Number: {vehicle.RegistrationNumber}, Color: {vehicle.Color}, Number of Wheels: {vehicle.NumberOfWheels}");
            }
        }

        public string ReadInput()
        {
            return Console.ReadLine()!;
        }

        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}

