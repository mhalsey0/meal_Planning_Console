namespace meal_Planning_Console
{
    public class GroceryList
    {
        public List<Ingredient> Ingredients { get; set; }

        public GroceryList()
        {

        }


        public static void CreateGroceryList(List<Ingredient> Ingredients)
        {
            GroceryList groceryList = new();

            foreach(Ingredient ingredient in Ingredients)
            {
                //not sure what to do here...
                //A grocery list should be a bigger list of ingredients from recipes
            }
        }
    }
}