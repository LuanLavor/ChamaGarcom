namespace ChamaGarcom.Models;

public class CallRequest
{
    public int Id { get; set; }

    public int RestaurantTableId { get; set; }
    public RestaurantTable RestaurantTable { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public bool IsCompleted { get; set; }
}