using ChamaGarcom.Data;
using ChamaGarcom.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ChamaGarcom.Hubs;

namespace ChamaGarcom.Pages;

public class DashboardModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly IHubContext<CallHub> _hub;

    public List<CallRequest> Calls { get; set; } = new List<CallRequest>();

    public DashboardModel(AppDbContext context, IHubContext<CallHub> hub)
    {
        _context = context;
        _hub = hub;
    }

    public void OnGet()
    {
        Calls = _context.CallRequests
            .Include(c => c.RestaurantTable)
            .Where(c => !c.IsCompleted)
            .OrderBy(c => c.CreatedAt)
            .ToList();
    }

    public async Task OnPostCompleteAsync(int id)
    {
        var call = await _context.CallRequests.FindAsync(id);
        if (call == null)
            return;

        call.IsCompleted = true;
        await _context.SaveChangesAsync();

        // Notifica todos que a chamada foi concluída
        await _hub.Clients.All.SendAsync("CallCompleted", call.RestaurantTableId);
    }
}
