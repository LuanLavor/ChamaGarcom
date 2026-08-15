using Microsoft.AspNetCore.SignalR;

namespace ChamaGarcom.Hubs
{
    public class CallHub : Hub
    {
        // Chamado quando uma nova chamada é criada
        public async Task SendCall(int tableId, int tableNumber)
        {
            // Envia para todos os clientes conectados (Dashboard)
            await Clients.All.SendAsync("ReceiveCall", tableId, tableNumber);
        }

        // Chamado quando a chamada é concluída
        public async Task CompleteCall(int tableId)
        {
            await Clients.All.SendAsync("CallCompleted", tableId);
        }
    }
}
