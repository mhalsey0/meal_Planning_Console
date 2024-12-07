using meal_Planning_Console;

class Program
{
    public static void Main(String[] args)
    {
        using (var db = new MealPlanningContext())
        {
            db.Database.EnsureCreated();
        }
        
        UserInterface.OnStart();
    }
}