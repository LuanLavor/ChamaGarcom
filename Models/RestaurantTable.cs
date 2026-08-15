namespace ChamaGarcom.Models;

public class RestaurantTable
{
    public int Id { get; set; }
    public int Number { get; set; }

    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
}