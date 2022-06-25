using System;
using NumeralSystemOperations;

namespace NumeralsTestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool inputIsValid = false;

            string inputToCheck;

            string number = "0";
            int currentBaseNumber = 0;
            int targetBaseNumber = 0;

            while (!inputIsValid)
            {
                Console.WriteLine("Enter a number you would like to convert: ");
                inputToCheck = Console.ReadLine();

                inputIsValid = (!string.IsNullOrWhiteSpace(inputToCheck));
            }

            inputIsValid = false;

            while (!inputIsValid)
            {
                Console.WriteLine("Enter the current base of the number you would like to convert: ");
                inputToCheck = Console.ReadLine();

                inputIsValid = (!string.IsNullOrWhiteSpace(inputToCheck) && int.TryParse(inputToCheck, out currentBaseNumber));

            }

            inputIsValid = false;

            while (!inputIsValid)
            {
                Console.WriteLine("Enter the target base for the number you would like to convert: ");
                inputToCheck = Console.ReadLine();

                inputIsValid = (!string.IsNullOrWhiteSpace(inputToCheck) && int.TryParse(inputToCheck, out targetBaseNumber));

            }

            Console.WriteLine(Numerals.ConvertNumericSystem(number, currentBaseNumber, targetBaseNumber).ToString());
        }
    }
}
