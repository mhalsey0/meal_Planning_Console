namespace meal_Planning_Console
{
    public class Ingredient
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

    }
}