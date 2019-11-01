using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp
{
    public interface IConnection<T>
    {
       void Add(T key, string connectionId);
       IEnumerable<string> GetConnections(T key);
        void Remove(T key, string connectionId);
    }
}
