using ChamaGarcom.Data;
using ChamaGarcom.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using ChamaGarcom.Hubs;

namespace ChamaGarcom.Pages;

public class CallModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly IHubContext<CallHub> _hub;

    public int TableId { get; set; }
    public int TableNumber { get; set; }
    public string? Message { get; set; }

    public CallModel(AppDbContext context, IHubContext<CallHub> hub)
    {
        _context = context;
        _hub = hub;
    }

    public void OnGet(int tableId)
    {
        var table = _context.RestaurantTables.Find(tableId);
        if (table == null)
        {
            Message = "Mesa não encontrada!";
            return;
        }

        TableId = tableId;
        TableNumber = table.Number;
    }

    public async Task OnPostAsync(int tableId)
    {
        var table = _context.RestaurantTables.Find(tableId);
        if (table == null)
        {
            Message = "Mesa não encontrada!";
            return;
        }

        var exists = _context.CallRequests.Any(c =>
            c.RestaurantTableId == tableId && !c.IsCompleted);

        if (exists)
        {
            Message = "? Aguarde, o garçom já foi chamado.";
            return;
        }

        var call = new CallRequest
        {
            RestaurantTableId = tableId,
            CreatedAt = DateTime.Now,
            IsCompleted = false
        };

        _context.CallRequests.Add(call);
        await _context.SaveChangesAsync();

        // Notifica o Dashboard via SignalR
        await _hub.Clients.All.SendAsync("ReceiveCall", tableId, table.Number);

        Message = "? Garçom chamado!";
    }
}
