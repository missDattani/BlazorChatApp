using Microsoft.AspNetCore.SignalR;

namespace BlazorChatApp
{
    public class BlazorChatSampleHub : Hub //Hub: A class in SignalR that handles client-server communication.
    {
        public const string HubUrl = "/chat"; //sets the default endpoint for the SignalR hub.

        public async Task BroadCast(string userName, string message) //Sends a message to all connected clients.
        {
            await Clients.All.SendAsync("Broadcast", userName, message);
        }

        public override Task OnConnectedAsync() //Handles logic when a client connects to the hub.(overrides the base class method):
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception) //Handles logic when a client disconnects from the hub. (overrides the base class method):
        {
            Console.WriteLine($"Disconnected {exception?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
