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

        public static int IntUserInput()
        {
            string? userInput = Console.ReadLine();
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

        public static string StringUserInput()
        {
            string? userInput = Console.ReadLine();
            
            if (userInput != null && userInput.Length > 1)
            {
                return userInput;
            }
            else
            {
                return "";
            }
        }

        public static void MenuSlection(int selection)
        {
            switch (selection)
            {
                case 0: //error handling from IntUserInput
                    Console.WriteLine("Please enter a valid selection");
                    Menu();
                    break;
                
                case 1: //create a new recipe
                    Recipe recipe = new ();

                    //adding list of ingredients
                    Console.WriteLine("How Many Ingredients do you have?");
                    int numberOfIngredients = IntUserInput();
                    List<Ingredient> ingredients = [];
                    for (int i = 0; i < numberOfIngredients; i++)
                    {
                        Ingredient ingredient = new();
                        Console.WriteLine("What is the name of the ingredient?");
                        ingredient.Name = StringUserInput();
                        Console.WriteLine("What is the description of the ingredient?");
                        ingredient.Description = StringUserInput();
                        Console.WriteLine("What is the unit of measurement for this ingredient?");
                        ingredient.Unit = StringUserInput();
                        Console.WriteLine($"How many {ingredient.Unit}(s) will this ingredient need?");
                        ingredient.Amount = IntUserInput();
                        ingredients.Add(ingredient);
                    }
                    recipe.Ingredients = ingredients;

                    //adding instructions
                    Console.WriteLine("Please write the instructions on how to prepare this recipe.");
                    recipe.Instructions = StringUserInput();

                    //adding description
                    Console.WriteLine("Please provide a brief description of your recipe");
                    recipe.Description = StringUserInput();

                    //adding serving size
                    Console.WriteLine("How many servings will this make? (leave blank if serving size is unkown)");
                    recipe.ServingSize = StringUserInput();

                    //adding name
                    Console.WriteLine("What is the name of this recipe?");
                    recipe.Name = StringUserInput();

                    break;

                case 2: //create a shopping list
                    Console.WriteLine("Which recipes will you be shoping for?");
                    //how will i recall previously entered recipes? where are they stored?
                    break;

                case 3: //exit the application
                    break;

            }
        }
    }
}