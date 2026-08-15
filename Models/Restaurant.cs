namespace ChamaGarcom.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<RestaurantTable> Tables { get; set; } = new List<RestaurantTable>();
}