﻿using Microsoft.AspNetCore.Identity;

namespace SellAndSwapGoodies.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; internal set; }
    }
}