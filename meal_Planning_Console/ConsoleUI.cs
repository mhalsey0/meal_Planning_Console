using System;
using System.Runtime.CompilerServices;

namespace meal_Planning_Console
{
    public class ConsoleUI
    {
        public static void OnStart()
        {
            Console.WriteLine("Welcome to the meal planning console app!");
            Menu();
            return;
        }

        public static void Menu()
        {
            Console.WriteLine("Please select from the following options:");
            Console.WriteLine("1: Enter a new recipe 2: Create a shopping list 3: Exit");
            return;
        }

        public static int UserInput()
        {
            string userInput = Console.ReadLine();
            bool success = int.TryParse(userInput, out int userInputNumber);

            if (success == false || userInputNumber > 3)
            {
                return 0;
            }
            else
            {
                return userInputNumber;
            }
        }
    }
}