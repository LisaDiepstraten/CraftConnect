using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.MockData    // move to unit tests
{
    public class MockAccountRepository : IAccountRepository
    {
        public List<Admin> admins = new List<Admin>();
        public List<Business> Businesses = new List<Business>();
        public List<User> Users = new List<User>();

        public bool AddUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public Admin AuthenticateAdminLogin(string username, string password)
        {
            foreach(var admin in admins)
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
            foreach(Business business in Businesses)
            {
                if(business.Username == username && business.Password == password)
                {
                    return business;
                }
            }
            return null;
        }

        public User AuthenticateUserLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool CreateAdmin(Admin admin)
        {
           admins.Add(admin);
            return true;
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
            foreach(Admin ad in admins)
            {
                if(admin == ad.Username)
                {
                    admins.Remove(ad);
                }
            }
            return true;
        }

        public bool DeleteBusiness(string businessname)
        {
            foreach( Business business in Businesses)
            {
                if(business.BusinessName == businessname)
                {
                    Businesses.Remove(business);
                }
            }
            return true;
        }

        public bool DeleteUser(string username)
        {
            foreach(User user in Users)
            {
                if(user.Username == username)
                {
                    Users.Remove(user);
                }
            }
            return true;
        }

        public bool EditAdmin(Admin admin)
        {
            foreach( Admin ad in admins)
            {
                if(ad.AdminId == admin.AdminId)
                {
                    admins.Remove(ad);
                    admins.Add(ad);
                }
            }
            return true;
        }

        public void EditBusiness(Business business)
        {
            throw new NotImplementedException();
        }

        public bool EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdmin(string username)
        {
            foreach(Admin admin in admins)
            {
                if(admin.Username == username)
                {
                    return admin;
                }
            }
            return null;
        }

        public List<Admin> GetAdmins()
        {
            return admins;
        }

        public List<Business> GetAllBusinesses()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Business GetBusinessByusername(string Username)
        {
            foreach(Business business in Businesses)
            {
                if(business.Username == Username)
                {
                    return business;
                }
            }
            return null;
        }

        public List<Business> GetBusinesses()
        {
            return Businesses;
        }

        public string GetHashedPasswordByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
