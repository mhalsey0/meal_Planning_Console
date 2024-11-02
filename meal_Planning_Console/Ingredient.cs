namespace meal_Planning_Console
{
    public class Ingredient
    {
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public static List<Ingredient> CreateGroceryList(List<Recipe> recipes)
        {
            List<Ingredient> groceryList = new();

            foreach(Recipe recipe in recipes)
            {
                List<Ingredient> ingredients = recipe.Ingredients;

                foreach(Ingredient ingredient in ingredients)
                {
                    int ingredientIndex = groceryList.FindIndex(x=> x.Name.Equals(ingredient.Name));

                    if (ingredientIndex == -1)
                    {
                        groceryList.Add(new Ingredient
                        {
                            Amount = ingredient.Amount,
                            Unit = ingredient.Unit,
                            Description = ingredient.Description,
                            Name = ingredient.Name,
                        });
                    }
                    else
                    {
                        groceryList[ingredientIndex].Amount += ingredient.Amount;
                    }                                      
                }                
            }
            return groceryList;
        }
    }
}