namespace meal_Planning_Console
{
    public class GroceryList
    {
        public int Id { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public List<Ingredient> Ingredients { get; set; }


        public GroceryList()
        {

        }

        public static List<Ingredient> consolidateIngredients(List<Recipe> recipes)
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