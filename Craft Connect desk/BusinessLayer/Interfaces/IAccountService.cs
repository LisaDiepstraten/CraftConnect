using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAccountService
    {
        public bool PasswordChecker(string password1, string password2);
        public Business AuthenticateBusiness(string username, string password);
        public bool AddBusiness(Business business);
        
        public Admin AuthenticateAdmin(string username, string password);
        //public void GetAllAdmins();
       
        public bool AddUser(User user);
        public string SetHashedPw(string password);
        public User AuthenticateUser(string username, string password);
        public string GetHashedPwByUsername(string username);
        public bool VerifyPassword(string providedPassword, string storedHash);
        public List<User> GetAllUsers();
        public Business GetBusinessByUserName(string username);
       
    }
}
