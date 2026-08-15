using Microsoft.AspNetCore.Mvc.RazorPages;
using ChamaGarcom.Data;

namespace ChamaGarcom.Pages;
public class TableModel : PageModel
{
    private readonly AppDbContext _db;

    public int TableId { get; set; }
    public int TableNumber { get; set; }

    public TableModel(AppDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        var table = _db.RestaurantTables.Find(id)!;
        TableId = table.Id;
        TableNumber = table.Number;
    }
}
