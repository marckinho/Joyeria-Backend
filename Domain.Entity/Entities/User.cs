﻿namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FisrtsName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}