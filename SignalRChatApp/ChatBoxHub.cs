using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp
{
    public class ChatBoxHub:Hub
    {
        private  IConnection<string> _connections;
        public ChatBoxHub(IConnection<string> connections)
        {
            _connections = connections;
        }
        public async Task SendMessage(string receiverUserId, string message)
        {
            foreach (var connectionId in _connections.GetConnections(receiverUserId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", receiverUserId, message);
            }
        }

        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);
            var a = 4;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception stopCalled)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnectedAsync(stopCalled);
        }
    }
}
