using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;

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
                        ListTypesAndCounts();
                        break;
                    case "5":
                        FindVehicleByRegistrationNumber();
                        break;
                    case "6":
                        SearchVehicles();
                        break;
                    case "7":
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
            WriteOutput("Enter registration number: ");
            string regNumber = ReadInput();
            WriteOutput("Enter color: ");
            string color = ReadInput();
            WriteOutput("Enter number of wheels: ");
            int wheels = int.Parse(ReadInput());

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
          //  WriteOutput("Types of vehicles and their counts in the garage:");
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

        private void SearchVehicles()
        {
            WriteOutput("Enter search criteria (e.g., number of wheels): ");
            string criteria = ReadInput();
            foreach (var vehicle in garageHandler.Search(vehicle => vehicle.Color.Equals(criteria, StringComparison.OrdinalIgnoreCase) || vehicle.NumberOfWheels.ToString().Equals(criteria)))
            {
                WriteOutput($"Registration Number: {vehicle.RegistrationNumber}, Color: {vehicle.Color}, Number of Wheels: {vehicle.NumberOfWheels}");
            }
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }

        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}

