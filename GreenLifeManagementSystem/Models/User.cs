using System;

namespace GreenLifeManagementSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}