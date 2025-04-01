using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CustomerSupportApp.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            try
            {
                var user = Context.User?.Identity?.Name;
                if (!string.IsNullOrEmpty(user))
                {
                    await Clients.All.SendAsync("ReceiveMessage", user, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SendMessage: {ex.Message}");
                throw;
            }
        }
    }

}
