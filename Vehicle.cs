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

       // void Start();
        //void Stop();
    }
    //class vehicle
    public class Vehicle : IVehicle 
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        // Constructor that accepts registration number, color, and fuel type
        public Vehicle(string regNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = regNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }
        
    }

    // subclass car
    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string regNumber, string color, int numberOfWheels, string fuelType) : base(regNumber, color, numberOfWheels)
        {
            NumberOfWheels = 4;
            FuelType = fuelType;
        }
        // Override ToString method to provide a custom string representation of a Car object
        public override string ToString()
        {
            return $"Car - Registration Number: {RegistrationNumber}, Color: {Color}, number of wheels: {NumberOfWheels} Fuel Type: {FuelType}";
        }
    }
    // subclass motorcycle
    public class Motorcycle : Vehicle
    {
        public string Cylinder { get; set; }

        public Motorcycle(string regNumber, string color, int numberOfWheels, string cylinder) : base(regNumber, color, numberOfWheels)
        {
            NumberOfWheels = 2;
            Cylinder = cylinder;
        }
        // Override ToString method to provide a custom string representation of a Car object
        public override string ToString()
        {
            return $"Motorcycle - Registration Number: {RegistrationNumber}, Color: {Color},  Type of motorcycle: {Cylinder}";
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
