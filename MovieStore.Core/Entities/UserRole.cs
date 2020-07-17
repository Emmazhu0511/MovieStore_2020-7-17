﻿using System;
namespace MovieStore.Core.Entities
{
    public class UserRole
    {
        public UserRole()
        {
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
