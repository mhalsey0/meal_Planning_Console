using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace meal_Planning_Console
{
    public class UserInterface
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
            MenuSlection(IntUserInput());
            Console.ReadLine(); //used to keep program running

            return;
        }

        public static int IntUserInput()
        {
            string? userInput = Console.ReadLine();
            bool success = int.TryParse(userInput, out int userInputNumber);

            if (success == false)
            {
                return -1;
            }
            else
            {
                return userInputNumber;
            }
        }

        public static List<int> ListUserInput()
        {
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid input.");

                return ListUserInput();
            }

            List<int> intList = new();

            foreach (char c in input)
            {
                if (char.IsNumber(c))
                {
                    int charToInt = (int)Char.GetNumericValue(c);
                    intList.Add(charToInt);
                }
            }
            return intList;
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
                case -1: //error handling from IntUserInput
                    Console.WriteLine("Please enter a valid selection");
                    Menu();
                    break;
                case 1: //create a new recipe
                    Recipe newRecipe = new();

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
                    newRecipe.Ingredients = ingredients;


                    Console.WriteLine("Please write the instructions on how to prepare this recipe.");
                    newRecipe.Instructions = StringUserInput();

                    Console.WriteLine("Please provide a brief description of your recipe");
                    newRecipe.Description = StringUserInput();

                    Console.WriteLine("How many servings will this make? (leave blank if serving size is unkown)");
                    newRecipe.ServingSize = StringUserInput();

                    Console.WriteLine("What is the name of this recipe?");
                    newRecipe.Name = StringUserInput();

                    break;

                case 2: //create a shopping list
                    Console.WriteLine("Which recipes will you be shopping for?");
                    List<Recipe> recipes = Recipe.GetRecipes();

                    //write all recipes to the console
                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine($"{i}: {recipes[i].Name}");
                    }
                    Console.WriteLine("Please type the number of each recipe you would like to shop for separated by a comma and a space:");
                    Console.WriteLine("(e.g. 1, 3, 4...)");

                    List<int> recipeSelectionIndexes = ListUserInput();
                    List<Recipe> selectedRecipes = new();

                    bool isError = false;
                    foreach (int index in recipeSelectionIndexes)
                    {
                        if (index < recipeSelectionIndexes.Count)
                        {
                            selectedRecipes.Add(recipes[index]);
                        }
                        else
                        {
                            string errorMessage = "The recipe index " + index + " does not exist. please try again";
                            Console.WriteLine(errorMessage);
                            isError = true;
                        }
                    }
                    if (isError)
                    {
                        break;
                    }
                    Console.WriteLine("You've selected the following recipes:");
                    foreach(Recipe recipe in selectedRecipes)
                    {
                        Console.WriteLine(recipe.Name);
                    }
                    
                    Console.WriteLine("Here is your grocery list");
                    List<Ingredient> consolidatedIngredients = GroceryList.ConsolidateIngredients(selectedRecipes);
                    GroceryList groceryList = new();
                    groceryList.Ingredients = consolidatedIngredients;

                    Console.WriteLine($"Grocery list for {groceryList.CreatedDate}");
                    foreach(Ingredient ingredient in groceryList.Ingredients)
                    {
                        double amount = ingredient.Amount;
                        string unit = ingredient.Unit;
                        string name = ingredient.Name;
                        Console.WriteLine($"{amount} {unit} {name}");
                    }
                    Console.WriteLine(groceryList.Ingredients);

                    break;

                case 3: //exit the application
                    return;

            }
            Menu();
            return;
        }
    }
}