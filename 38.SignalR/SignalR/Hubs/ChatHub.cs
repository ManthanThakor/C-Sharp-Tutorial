using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SignalR.Hubs
{


    public class ChatHub : Hub
    {
        private static Dictionary<string, string> ConnectedUsers = new();

        public async Task SetUsername(string username)
        {
            if (!ConnectedUsers.ContainsKey(username))
            {
                ConnectedUsers[username] = Context.ConnectionId;
                await Clients.Caller.SendAsync("ReceivePrivateMessage", "System", $"You are connected as {username}");
            }
            else
            {
                await Clients.Caller.SendAsync("ReceivePrivateMessage", "System", "Username already in use.");
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = ConnectedUsers.FirstOrDefault(u => u.Value == Context.ConnectionId);
            if (user.Key != null)
            {
                ConnectedUsers.Remove(user.Key);
            }
            await base.OnDisconnectedAsync(exception);
        }

        // ✅ Private Message Handling
        public async Task SendPrivateMessage(string toUser, string message)
        {
            if (ConnectedUsers.TryGetValue(toUser, out string connectionId))
            {
                string fromUser = ConnectedUsers.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
                await Clients.Client(connectionId).SendAsync("ReceivePrivateMessage", fromUser, message);
            }
            else
            {
                await Clients.Caller.SendAsync("ReceivePrivateMessage", "System", "User not found.");
            }
        }

        // ✅ Group Chat Handling
        public async Task CreateGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            string user = ConnectedUsers.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", "System", $"{user} joined the group {groupName}");
        }

        public async Task SendMessageToGroup(string groupName, string message)
        {
            string user = ConnectedUsers.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", user, message);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }



}
