// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using Ovning5;

public class Program
{
    
        static void Main(string[] args)
        {
        ConsoleUI consoleUI = new ConsoleUI(10); // Example: garage with capacity of 10 vehicles
        consoleUI.WriteOutput("Welcome to the Garage Management System!");
        consoleUI.Run();
        consoleUI.WriteOutput("Exiting the application. Goodbye!");
    }
    




}
