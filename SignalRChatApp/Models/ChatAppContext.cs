using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp.Models
{
    public class ChatAppContext : IdentityDbContext
    {
        public ChatAppContext(DbContextOptions<ChatAppContext> options)
            : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
    }
}
