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
                var user = Context.User?.Identity?.Name; // Get the logged-in user's name
                if (!string.IsNullOrEmpty(user))
                {
                    await Clients.All.SendAsync("ReceiveMessage", user, message);
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in SendMessage: {ex.Message}");
                throw; // Re-throw the exception for SignalR to handle
            }
        }
    }

}
