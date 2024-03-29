﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CarBlog2.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
