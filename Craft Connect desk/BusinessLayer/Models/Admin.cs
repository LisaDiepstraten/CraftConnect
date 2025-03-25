using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Admin    
    {
        public int? AdminId { get; private set; }
        public string AdminDepartment { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Admin(int? adminid, string admindepartment, string username, string password)
        {
            this.AdminId = adminid > 0 ? adminid : throw new ArgumentException("Admin ID must be a positive integer.", nameof(adminid));
            this.AdminDepartment = !string.IsNullOrWhiteSpace(admindepartment) ? admindepartment : throw new ArgumentException("Admin department cannot be null or whitespace.", nameof(admindepartment));
            this.Username = !string.IsNullOrWhiteSpace(username) ? username : throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
            this.Password = !string.IsNullOrWhiteSpace(password) ? password : throw new ArgumentException("Password cannot be null or whitespace..", nameof(password));

           
        }

    }   
}
