﻿using System.ComponentModel.DataAnnotations;

namespace PriceScreen.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool KeepLoggedIn { get; set; }
        //public string Role { get; set; }    
    }
}
