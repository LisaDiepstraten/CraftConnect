
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAccountRepository
    {

        public Business AuthenticateBusinessLogin(string username, string password);
        public bool CreateBusiness(Business business);
      
        public Admin AuthenticateAdminLogin(string username, string password);
       
        public User GetUserById(int userId);

        public string GetHashedPasswordByUsername(string username);
        public User AuthenticateUserLogin(string username, string password);
        public bool AddUser(User newUser);
        public List<User> GetAllUsers();
        public Business GetBusinessByusername(string Username);
       
    }
}
