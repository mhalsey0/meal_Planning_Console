namespace meal_Planning_Console
{
    public class Recipe
    {
        public required string Name { get; set;}
        public required string Description { get; set;}
        public required List<Ingredient> Ingredients { get; set;}
        public string ServingSize { get; set;} = "";

        //Constructors
        public Recipe(string name, string description, List<Ingredient> ingredients, string servingSize)
        {
            this.Name = name;
            this.Description = description;
            this.Ingredients = ingredients;
            this.ServingSize = servingSize;
        }
    }
}