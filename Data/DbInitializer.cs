using ChamaGarcom.Models;


namespace ChamaGarcom.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Restaurants.Any())
                return;

            var restaurant = new Restaurant { Name = "Restaurante Demo" };

            for (int i = 1; i <= 10; i++)
            {
                restaurant.Tables.Add(new RestaurantTable { Number = i });
            }

            context.Restaurants.Add(restaurant);
            context.SaveChanges();
        }
    }

}
