﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<RefreshTokenRecord> RefreshTokens { get; set; } = new List<RefreshTokenRecord>();

    }
}
