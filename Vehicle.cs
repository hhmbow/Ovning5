using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ovning5.Vehicle;

namespace Ovning5
{

    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }

    }
  
    public class Vehicle : IVehicle
    {
        private string registrationNumber;
        private string color;
        private int numberOfWheels;

        public string RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Registration number cannot be null or whitespace.");
                registrationNumber = value;
            }
        }

        public string Color
        {
            get => color;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Color cannot be null or whitespace.");
                color = value;
            }
        }

        public int NumberOfWheels
        {
            get => numberOfWheels;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Number of wheels must be greater than zero.");
                numberOfWheels = value;
            }
        }

        public Vehicle(string regNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = regNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }
    }

  
 
    public class Car : Vehicle
    {
        private string fuelType;

        public string FuelType
        {
            get => fuelType;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Fuel type cannot be null or whitespace.");
                fuelType = value;
            }
        }

        public Car(string regNumber, string color, int numberOfWheels, string fuelType)
            : base(regNumber, color, ValidateNumberOfWheels(numberOfWheels))
        {
            FuelType = fuelType;
        }

        private static int ValidateNumberOfWheels(int numberOfWheels)
        {
            if (numberOfWheels != 4)
                throw new ArgumentException("A car must have 4 wheels.");
            return numberOfWheels;
        }

        public override string ToString()
        {
            return $"Car - Registration Number: {RegistrationNumber}, Color: {Color}, Number of Wheels: {NumberOfWheels}, Fuel Type: {FuelType}";
        }
    }


    public class Motorcycle : Vehicle
    {
        public string Cylinder { get; set; }

        public Motorcycle(string regNumber, string color, int numberOfWheels, string cylinder)
            : base(regNumber, color, ValidateNumberOfWheels(numberOfWheels))
        {
            Cylinder = cylinder;
        }

        private static int ValidateNumberOfWheels(int numberOfWheels)
        {
            if (numberOfWheels < 2 || numberOfWheels > 4)
                throw new ArgumentException("A motorcycle must have 2, 3, or 4 wheels.");
            return numberOfWheels;
        }

        public override string ToString()
        {
            return $"Motorcycle - Registration Number: {RegistrationNumber}, Color: {Color}, Number of Wheels: {NumberOfWheels}, Type of Motorcycle: {Cylinder}";
        }
    }

    // subclass bus
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string regNumber, string color, int numberOfWheels, int seats) : base(regNumber, color, numberOfWheels)
        {
            NumberOfWheels = 6;
            NumberOfSeats = seats;
        }
        // Override ToString method to provide a custom string
        public override string ToString()
        {
            return $"Bus - Registration Number: {RegistrationNumber}, Color: {Color}, Nuber of seats: {NumberOfSeats}";
        }

    }
    // subclass airplane
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(string regNumber, string color, int numberOfWheels, int engines) : base(regNumber, color, numberOfWheels)
        {
            NumberOfWheels = 16;
            NumberOfEngines = engines;
        }
        // Override ToString method to provide a custom string
        public override string ToString()
        {
            return $"Airplane - Registration Number: {RegistrationNumber}, Color: {Color}, Fuel Type: {NumberOfEngines}";
        }
    }
    // subclass boat
    public class Boat : Vehicle
    {
        public string Lenght { get; set; }

        public Boat(string regNumber, string color, int numberOfWheels, string lenght) : base(regNumber, color, numberOfWheels)
        {
            NumberOfWheels = 0;
            Lenght = lenght;
        }
        // Override ToString method to provide a custom string 
        public override string ToString()
        {
            return $"Boat - Registration Number: {RegistrationNumber}, Color: {Color},  Type of boat: {Lenght}";
        }
    }

}
