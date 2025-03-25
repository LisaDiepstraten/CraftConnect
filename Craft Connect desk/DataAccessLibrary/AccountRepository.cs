using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace DataAccessLibrary
{
    public class AccountRepository : IAccountRepository
    {
        Connection connectionstring = new Connection();

        public Business AuthenticateBusinessLogin(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string query = "SELECT BusinessId, BusinessName, BusinessImage, FirstName, LastName, PhoneNumber, Address, EmailAddress FROM dbo.Business WHERE UsernameB = @Username AND PasswordB = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int businessId = reader.GetInt32(0);
                                string businessName = reader.GetString(1);
                                string businessImage = reader.GetString(2);
                                string firstName = reader.GetString(3);
                                string lastName = reader.GetString(4);
                                string phoneNumber = reader.GetString(5);
                                string address = reader.GetString(6);
                                string emailAddress = reader.GetString(7);

                                Business business = new Business(businessId, businessName, businessImage, firstName, lastName, phoneNumber, address, emailAddress, username, password);

                                return business;
                            }
                        }
                    }

                    connection.Close();

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("Error occurred in Business login", ex);

            }
        }

        public bool CreateBusiness(Business business)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO dbo.Business (BusinessName, BusinessImage, FirstName, LastName, PhoneNumber, Address, EmailAddress, UsernameB, PasswordB) VALUES (@BusinessName, @BusinessImage, @FirstName, @LastName, @PhoneNumber, @Address, @EmailAddress, @UsernameB, @PasswordB)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parameters for the insert query
                        command.Parameters.AddWithValue("@BusinessName", business.BusinessName);
                        command.Parameters.AddWithValue("@BusinessImage", business.BusinessImage);
                        command.Parameters.AddWithValue("@FirstName", business.FirstName);
                        command.Parameters.AddWithValue("@LastName", business.LastName);
                        command.Parameters.AddWithValue("@PhoneNumber", business.PhoneNumber);
                        command.Parameters.AddWithValue("@Address", business.Address);
                        command.Parameters.AddWithValue("@EmailAddress", business.EmailAddress);
                        command.Parameters.AddWithValue("@UsernameB", business.Username);
                        command.Parameters.AddWithValue("@PasswordB", business.Password);

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle specific SQL exceptions
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
                // Handle general exceptions
                throw new DatabaseExceptionHandler($"Error in CreateBusiness: {ex.Message}", ex);
            }
        }

        public Business GetBusinessByusername(string Username)
        {
            try
            {
                string query = "SELECT * FROM Business WHERE UsernameB = @UsernameB;";
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UsernameB", Username);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int businessid = reader.GetInt32(0);
                                string businessname = reader.GetString(1);
                                string businessimage = reader.GetString(2);
                                string firstname = reader.GetString(3);
                                string lastname = reader.GetString(4);
                                string phonenumber = reader.GetString(5);
                                string address = reader.GetString(6);
                                string emailaddress = reader.GetString(7);
                                string username = reader.GetString(8);
                                string password = reader.GetString(9);

                                Business bus = new Business(businessid, businessname, businessimage, firstname, lastname, phonenumber, address, emailaddress, username, password);

                                return bus;
                            }
                            else
                            {
                                throw new BusinessNotFoundException($"Business with username {Username} not found.");
                            }
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("Error occurred while fetching business by username", ex);

            }
        }

      

        public Admin AuthenticateAdminLogin(string username, string password)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
            {
                connection.Open();

                string query = "SELECT AdminId, AdminDepartment FROM dbo.Admin WHERE UsernameA = @Username AND PasswordA = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int adminId = reader.GetInt32(0);
                            string admindepartment = reader.GetString(1);

                            Admin admin = new Admin(adminId, admindepartment, username, password);

                            return admin;
                        }
                        
                    }
                }

                return null;
            }


        }

       
        public User GetUserById(int userId)
        {
            try
            {
                User user = null;

                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = "SELECT UserId, Username, FirstName, LastName, PhoneNumber, Address, EmailAddress, Password, Points, CartId FROM dbo.[User] WHERE UserId = @UserId";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string username = reader.GetString(1);
                                string firstname = reader.GetString(2);
                                string lastname = reader.GetString(3);
                                string phonenumber = reader.GetString(4);
                                string address = reader.GetString(5);
                                string emailaddress = reader.GetString(6);
                                string password = reader.GetString(7);
                                int points = reader.GetInt32(8);
                                int shoppingcartid = reader.GetInt32(9);

                                user = new User(id, username, firstname, lastname, phonenumber, address, emailaddress, password, points, shoppingcartid);
                            }
                            else
                            {
                                throw new DatabaseExceptionHandler($"User with ID {userId} not found.");
                            }
                        }
                    }
                }

                return user;
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = $"SQL Exception occurred in GetUserById: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            
            
            catch (Exception ex)
            {
                string errorMessage = $"Exception occurred in GetUserById: {ex.Message}";
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
        }



        public User AuthenticateUserLogin(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string query = "SELECT UserId, Username, FirstName, LastName, PhoneNumber, Address, EmailAddress, Points, CartId FROM dbo.[User] WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                string userUsername = reader.GetString(1);
                                string firstName = reader.GetString(2);
                                string lastName = reader.GetString(3);
                                string phoneNumber = reader.GetString(4);
                                string address = reader.GetString(5);
                                string emailAddress = reader.GetString(6);
                                int points = reader.GetInt32(7);
                                int cartId = reader.GetInt32(8);

                                // Create a new User object with the retrieved data
                                User user = new User(userId, userUsername, firstName, lastName, phoneNumber, address, emailAddress, password, points, cartId);

                                return user;
                            }
                            else
                            {
                                throw new UserNotFoundException($"User with username {username} not found.");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("Error occurred in User login", ex);

            }
        }


        public bool AddUser(User newUser)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Insert a new Cart entry and get the new CartID
                    string insertCartQuery = "INSERT INTO dbo.Cart DEFAULT VALUES; SELECT SCOPE_IDENTITY();";
                    int newCartId;

                    using (SqlCommand insertCartCommand = new SqlCommand(insertCartQuery, connection))
                    {
                        newCartId = Convert.ToInt32(insertCartCommand.ExecuteScalar());
                    }

                    // Insert the new User entry with the new CartID
                    string insertUserQuery = "INSERT INTO dbo.[User] (Username, FirstName, LastName, PhoneNumber, Address, EmailAddress, Password, Points, CartId) " +
                                             "VALUES (@Username, @FirstName, @LastName, @PhoneNumber, @Address, @EmailAddress, @Password, @Points, @CartId)";

                    using (SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, connection))
                    {
                        insertUserCommand.Parameters.AddWithValue("@Username", newUser.Username);
                        insertUserCommand.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                        insertUserCommand.Parameters.AddWithValue("@LastName", newUser.LastName);
                        insertUserCommand.Parameters.AddWithValue("@PhoneNumber", newUser.PhoneNumber);
                        insertUserCommand.Parameters.AddWithValue("@Address", newUser.Address);
                        insertUserCommand.Parameters.AddWithValue("@EmailAddress", newUser.EmailAddress);
                        insertUserCommand.Parameters.AddWithValue("@Password", newUser.Password);
                        insertUserCommand.Parameters.AddWithValue("@Points", newUser.Points);
                        insertUserCommand.Parameters.AddWithValue("@CartId", newCartId);

                        int rowsAffected = insertUserCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // User added successfully
                            return true;
                        }
                        else
                        {
                            // User not added (possibly due to some error)
                            return false;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = $"SQL Exception occurred in AddUser: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (DatabaseExceptionHandler)
            {
                // Re-throw DatabaseExceptionHandler to be caught and handled separately
                throw;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Exception occurred in AddUser: {ex.Message}";
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = @"
            SELECT [UserId]
                  ,[Username]
                  ,[FirstName]
                  ,[LastName]
                  ,[PhoneNumber]
                  ,[Address]
                  ,[EmailAddress]
                  ,[Password]
                  ,[Points]
                  ,[CartId]
            FROM [dbi523722_craftconn].[dbo].[User]";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int? userId = reader["UserId"] != DBNull.Value ? (int?)Convert.ToInt32(reader["UserId"]) : null;
                                string username = reader["Username"].ToString();
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();
                                string phoneNumber = reader["PhoneNumber"].ToString();
                                string address = reader["Address"].ToString();
                                string emailAddress = reader["EmailAddress"].ToString();
                                string password = reader["Password"].ToString();
                                int points = Convert.ToInt32(reader["Points"]);
                                int? cartId = reader["CartId"] != DBNull.Value ? (int?)Convert.ToInt32(reader["CartId"]) : null;

                                User user = new User(userId, username, firstName, lastName, phoneNumber, address, emailAddress, password, points, cartId);

                                userList.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                throw new DatabaseExceptionHandler("Error occurred while fetching all users", ex);

            }

            return userList;
        }



        public string GetHashedPasswordByUsername(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string query = "SELECT Password FROM dbo.[User] WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        // Execute the query and retrieve the hashed password
                        string hashedPassword = command.ExecuteScalar() as string;

                        if (hashedPassword != null)
                        {
                            return hashedPassword; 
                        }
                        else
                        {
                            throw new UserNotFoundException($"User with username '{username}' not found.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = $"SQL Exception occurred in GetHashedPasswordByUsername: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (UserNotFoundException)
            {
                // Re-throw UserNotFoundException to be caught and handled separately
                throw;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Exception occurred in GetHashedPasswordByUsername: {ex.Message}";
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
        }

        

    }
}

