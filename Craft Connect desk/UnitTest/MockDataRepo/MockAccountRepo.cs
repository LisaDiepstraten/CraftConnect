using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MockDataRepo
{
    public class MockAccountRepo : IAccountRepository
    {
        private List<Admin> admins = new List<Admin>();
        private List<Business> Businesses = new List<Business>();
        private List<User> Users = new List<User>();

        public bool AddUser(User newUser)
        {
            if (newUser != null)
            {
                Users.Add(newUser);
                return true;
            }
            return false;
        }

        public Admin AuthenticateAdminLogin(string username, string password)
        {
            Admin oneadmin = new Admin(1, "Software", "SoftwareD", "TheBest123");
            admins.Add(oneadmin);
            foreach (var admin in admins)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    return admin;
                }
            }
            return null;
        }

        public Business AuthenticateBusinessLogin(string username, string password)
        {
            Business bus = new Business(1, "Zoe craft", "test.jpg", "Zoe", "Johnsen", "023846284", "Eindhoven", "Zoe@gmail.com", "ZoeJ", "Hello123!");
            Businesses.Add(bus);
            Business bis = null;
            foreach (Business business in Businesses)
            {
                if (business.Username == username && business.Password == password)
                {
                    bis= business;
                }
            }
            return bis;
        }

        public User AuthenticateUserLogin(string username, string password)
        {
            foreach (User user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

      

        public bool CreateBusiness(Business business)
        {
            Businesses.Add(business);
            return true;
        }

        public bool CreateUser(User user)
        {
            Users.Add(user);
            return true;
        }

        public bool DeleteAdmin(string admin)
        {
            foreach (Admin ad in admins)
            {
                if (admin == ad.Username)
                {
                    admins.Remove(ad);
                }
            }
            return true;
        }

        public bool DeleteBusiness(string businessname)
        {
            foreach (Business business in Businesses)
            {
                if (business.BusinessName == businessname)
                {
                    Businesses.Remove(business);
                }
            }
            return true;
        }

        public bool DeleteUser(string username)
        {
            foreach (User user in Users)
            {
                if (user.Username == username)
                {
                    Users.Remove(user);
                }
            }
            return true;
        }



        public bool EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdmin(string username)
        {
            foreach (Admin admin in admins)
            {
                if (admin.Username == username)
                {
                    return admin;
                }
            }
            return null;
        }

   
     

        public List<User> GetAllUsers()
        {
            return Users;
        }

        public Business GetBusinessByusername(string Username)
        {
            foreach (Business business in Businesses)
            {
                if (business.Username == Username)
                {
                    return business;
                }
            }
            return null;
        }

      

        public string GetHashedPasswordByUsername(string username)
        {
            foreach(User user in Users)
            {
                if (user.Username == username)
                {
                    return user.Password;
                }
            }
            return null;
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
