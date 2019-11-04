using Microsoft.AspNetCore.SignalR;
using SignalRChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp
{
    public class ChatBoxHub:Hub
    {
        private IConnection _UserConnections;
        private ChatAppContext _ChatAppContext;

        public ChatBoxHub(ChatAppContext ChatAppContext,IConnection connection)
        {
            _UserConnections = connection;
            _ChatAppContext = ChatAppContext;
        }

        public async Task SendMessage(string receiverUserId, string message)
        {

            string connectionId = _UserConnections.GetConnections(receiverUserId);
            string receiverName = _ChatAppContext.Users.Find(receiverUserId).Name;
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", receiverName, message);
           
        }

        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;
            string loggedInUserId = _ChatAppContext.Users.Where(u => u.Email == name).SingleOrDefault().Id;
            _UserConnections.Add(loggedInUserId, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception stopCalled)
        {
            string name = Context.User.Identity.Name;
            string loggedInUserId = _ChatAppContext.Users.Where(u => u.Email == name).SingleOrDefault().Id;
            _UserConnections.Remove(loggedInUserId, Context.ConnectionId );
            return base.OnDisconnectedAsync(stopCalled);
        }
    }
}
