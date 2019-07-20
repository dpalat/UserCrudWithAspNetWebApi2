﻿using System;
using System.Collections.Generic;

namespace UserCrud.WebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserToken { get; set; }
        public List<string> Roles { get; set; }
    }
}