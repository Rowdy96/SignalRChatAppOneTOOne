﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp.Models
{
    public class Users:IdentityUser
    {
        public string Name { get; set; }
    }
}
