using BCrypt.Net;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Services
{
    public class AccountService : IAccountService // alle service methods maar niet implementatie
    {

        private IAccountRepository repo;

        public AccountService(IAccountRepository repo)
        {
            this.repo = repo;
            //Account helper implement 
        }


        public Admin AuthenticateAdmin(string username, string password)
        {
            Admin admin = repo.AuthenticateAdminLogin(username, password);

            return admin;

        }

        public bool PasswordChecker(string password1, string password2)
        {
            try
            {
                return password1 == password2;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("An error occurred while checking the password.", ex);
            }
        }

        public Business AuthenticateBusiness(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Please fill in your credentials");
                }

                return repo.AuthenticateBusinessLogin(username, password);
            }
            catch (ArgumentException ex)
            {
                
                throw new ArgumentException("Invalid username or password.", ex);
            }
            catch (Exception ex)
            {
               
                throw new Exception("An error occurred while authenticating the business.", ex);
            }
        }

        public bool AddBusiness(Business business)
        {
            try
            {
                if (business == null)
                {
                    throw new ArgumentNullException(nameof(business));
                }

                if (business.PhoneNumber.Length != 9)
                {
                    throw new ArgumentException("Please fill in a valid phone number with 9 numbers", nameof(business.PhoneNumber));
                }

                if (!business.EmailAddress.Contains("@"))
                {
                    throw new ArgumentException("Invalid email address. Please include the '@' symbol.", nameof(business.EmailAddress));
                }

                if (string.IsNullOrEmpty(business.Username) || string.IsNullOrEmpty(business.Password))
                {
                    throw new ArgumentException("Please fill in your credentials");
                }

                business.SetPassword(business.Password);
                return repo.CreateBusiness(business);
               
            }
            catch (ArgumentException ex)
            {
                // handling validation errors
                throw new ArgumentException("Invalid business data provided.", ex);
            }
            catch (SqlException sqlEx)
            {
                // Handling specific SQL exceptions
                switch (sqlEx.Number)
                {
                    case 547: // Foreign key constraint violation
                        throw new DatabaseExceptionHandler("Error creating business. Foreign key constraint violated.", sqlEx);
                    case 2627: // Unique constraint violation (duplicate key)
                        throw new DatabaseExceptionHandler("Error creating business. Duplicate key violation.", sqlEx);
                    default:
                        throw new DatabaseExceptionHandler("Error creating business.", sqlEx);
                }
            }
            catch (Exception ex)
            {
                // Any other unexpected exceptions
                throw new Exception("An error occurred while adding the business.", ex);
            }
        }


        public string GetHashedPwByUsername(string username)
        {
            try
            {
                if (username != null)
                {
                    return repo.GetHashedPasswordByUsername(username);
                }
                throw new ArgumentException("Please fill in your Username");
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = $"SQL Exception occurred in GetHashedPasswordByUsername: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
           
            catch (Exception ex)
            {
              
                throw new Exception("An error occurred while getting the hashed password by username.", ex);
            }
        }

        public bool VerifyPassword(string providedPassword, string storedHash)
        {
            try
            {
                if (providedPassword != null)
                {
                    return BCrypt.Net.BCrypt.EnhancedVerify(providedPassword, storedHash);
                }
                throw new ArgumentException("Please fill in your credentials");
            }
            catch (Exception ex)
            {
           
                throw new Exception("An error occurred while verifying the password.", ex);
            }
        }

        public User AuthenticateUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Please fill in your credentials");
                }

                return repo.AuthenticateUserLogin(username, password);
            }
            
            catch (Exception ex)
            {
        
                throw new Exception("An error occurred while authenticating the user.", ex);
            }
        }

        public bool AddUser(User user)
        {
            try
            {
                bool NewUsername = true;
                foreach (User person in GetAllUsers())
                {
                    if (user.Username == person.Username)
                    {
                        NewUsername = false;
                        break;
                    }
                }

                if (user.PhoneNumber.Length != 9)
                {
                    throw new ArgumentException("Please fill in a valid phone number with 9 numbers", nameof(user.PhoneNumber));
                }

                if (!user.EmailAddress.Contains("@"))
                {
                    throw new ArgumentException("Invalid email address. Please include the '@' symbol.", nameof(user.EmailAddress));
                }

                if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                {
                    throw new ArgumentException("Please fill in your credentials");
                }

                if (NewUsername)
                {
                    user.SetPassword(user.Password); // here I hash the password
                    return repo.AddUser(user);
                }
                return NewUsername;
            }
            catch (SqlException sqlEx)
            {
                // Handling specific SQL exceptions
                string errorMessage = $"SQL Exception occurred in AddUser: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Handling any other generic exceptions
                string errorMessage = $"Exception occurred in AddUser: {ex.Message}";
                throw new Exception(errorMessage, ex);
            }
        }

        public string SetHashedPw(string password)
        {
            try
            {
                if (password != null)
                {
                    return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
                }
                throw new ArgumentException("Please fill in your credentials");
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while setting the hashed password.", ex);
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return repo.GetAllUsers();
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Handling specific database exceptions
                throw new DatabaseExceptionHandler("Database error occurred while getting all users", dbEx);
            }
            catch (Exception ex)
            {
          
                throw new Exception("An error occurred while getting all users.", ex);
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                return repo.GetUserById(userId);
            }
            catch (SqlException sqlEx)
            {
                // Handling specific SQL exceptions (e.g., connectivity, query errors)
                throw new DatabaseExceptionHandler($"SQL Exception occurred in GetUserById: {sqlEx.Message}", sqlEx);
            }
            catch (Exception ex)
            {
                // Log or handle other unexpected exceptions
                throw new DatabaseExceptionHandler($"Exception occurred in GetUserById: {ex.Message}", ex);
            }
        }

        public Business GetBusinessByUserName(string username)
        {
            try
            {
                return repo.GetBusinessByusername(username);
            }
            catch (BusinessNotFoundException ex)
            {
                // handling BusinessNotFoundException
                throw new BusinessNotFoundException($"Business with username '{username}' not found.", ex);
            }
            catch (DatabaseExceptionHandler ex)
            {
                // handling DatabaseExceptionHandler
                throw new DatabaseExceptionHandler("Error occurred while fetching business by username", ex);
            }
            catch (Exception ex)
            {
               
                throw new Exception("An error occurred while getting the business by username.", ex);
            }
        }

    }
}
