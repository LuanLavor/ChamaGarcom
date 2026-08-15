using Microsoft.EntityFrameworkCore;
using ChamaGarcom.Models;

namespace ChamaGarcom.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<RestaurantTable> RestaurantTables => Set<RestaurantTable>();
    public DbSet<CallRequest> CallRequests => Set<CallRequest>();
}
