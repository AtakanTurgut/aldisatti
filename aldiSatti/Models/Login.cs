﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aldiSatti.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Adı")]
        public string userName { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}