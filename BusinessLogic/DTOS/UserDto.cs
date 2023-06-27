﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOS
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }
    }
}
