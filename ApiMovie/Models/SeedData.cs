public class SeedData
{
    public static void Init()
    {
        using (var context = new MovieContext())
        {
            // Look for existing content
            if (context.Movies.Any())
            {
                return;   // DB already filled
            }

            // Add students
            Movie movie1 = new Movie
            {
                Id = 1,
                Title = "Le roi et l'oiseau",
                Genre = "Film d'animation",
                Note = 5
            };
            Movie movie2 = new Movie
            {
                Id = 2,
                Title = "Le petit poucet",
                Genre = "Film pour enfant",
                Note = 7
            };
            Movie movie3 = new Movie
            {
                Id = 3,
                Title = "Harry Potter",
                Genre = "Film fantastique",
                Image = "Sorcier avec baguette magique",
                Abstract = "Film sympa",
                Note = 10
            };
            
            

            // Commit changes into DB
            context.SaveChanges();
        }
    }
}