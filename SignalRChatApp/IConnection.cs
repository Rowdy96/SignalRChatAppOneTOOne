using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp
{
    public interface IConnection
    {
       void Add(string userId, string connectionId);
       string GetConnections(string userId);
       void Remove(string userId, string connectionId);
    }
}
