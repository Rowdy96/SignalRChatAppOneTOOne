using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp
{
    public class ConnectionMapping:IConnection
    {
        public List<UserConnection> _connections = new List<UserConnection>();
         
        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public void Add(string userId, string connectionId)
        {
            _connections.Add(new UserConnection { UserId = userId , ConnectionId = connectionId });
        }

        public string GetConnections(string userId)
        {
            return _connections.Find(u=>u.UserId == userId).ConnectionId;
        }

        public void Remove(string userId, string connectionId)
        {
            _connections.Remove(new UserConnection { UserId = userId, ConnectionId = connectionId });
            
        }
    }
}
