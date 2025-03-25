using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class CartRepository : ICartRepository
    {
        Connection connectionstring = new Connection();


        public void AddWorkshopToCart(int ShoppingcartId, int workshopid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Check if the workshop already exists in the cart
                    string selectQuery = "SELECT Quantity FROM dbo.CartItem WHERE CartId = @CartId AND WorkshopId = @WorkshopId";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@CartId", ShoppingcartId);
                        selectCommand.Parameters.AddWithValue("@WorkshopId", workshopid);

                        object existingQuantity = selectCommand.ExecuteScalar();

                        if (existingQuantity != null) // Workshop exists, update quantity
                        {
                            int newQuantity = (int)existingQuantity + 1; // Increase quantity by 1
                            string updateQuery = "UPDATE dbo.CartItem SET Quantity = @Quantity WHERE CartId = @CartId AND WorkshopId = @WorkshopId";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Quantity", newQuantity);
                                updateCommand.Parameters.AddWithValue("@CartId", ShoppingcartId);
                                updateCommand.Parameters.AddWithValue("@WorkshopId", workshopid);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else // Workshop does not exist, insert new workshop
                        {
                            string insertQuery = "INSERT INTO dbo.CartItem (CartId, WorkshopId, ProductId, Quantity) VALUES (@CartId, @WorkshopId, @ProductId, @Quantity)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@CartId", ShoppingcartId);
                                insertCommand.Parameters.AddWithValue("@WorkshopId", workshopid);
                                insertCommand.Parameters.AddWithValue("@ProductId", DBNull.Value); // setting a null value
                                insertCommand.Parameters.AddWithValue("@Quantity", 1);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions
                string errorMessage = $"SQL Exception in AddWorkshopToCart: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                string errorMessage = $"Exception in AddWorkshopToCart: {ex.Message}";
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
        }

        public void AddProductToCart(int ShoppingcartId, int productid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Check if the item already exists in the cart
                    string selectQuery = "SELECT Quantity FROM dbo.CartItem WHERE CartId = @CartId AND ProductId = @ProductId";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@CartId", ShoppingcartId);
                        selectCommand.Parameters.AddWithValue("@ProductId", productid);

                        object existingQuantity = selectCommand.ExecuteScalar();

                        if (existingQuantity != null) // Item exists, update quantity
                        {
                            int newQuantity = (int)existingQuantity + 1; // Increase quantity by 1
                            string updateQuery = "UPDATE dbo.CartItem SET Quantity = @Quantity WHERE CartId = @CartId AND ProductId = @ProductId";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Quantity", newQuantity);
                                updateCommand.Parameters.AddWithValue("@CartId", ShoppingcartId);
                                updateCommand.Parameters.AddWithValue("@ProductId", productid);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else // Item does not exist, insert new item
                        {
                            string insertQuery = "INSERT INTO dbo.CartItem (CartId, WorkshopId, ProductId, Quantity) VALUES (@CartId, @WorkshopId, @ProductId, @Quantity)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@CartId", ShoppingcartId);
                                insertCommand.Parameters.AddWithValue("@WorkshopId", DBNull.Value); // setting a null value
                                insertCommand.Parameters.AddWithValue("@ProductId", productid);
                                insertCommand.Parameters.AddWithValue("@Quantity", 1);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions
                string errorMessage = $"SQL Exception in AddWorkshopToCart: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                string errorMessage = $"Exception in AddWorkshopToCart: {ex.Message}";
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
        }

        public List<int> GetProductsInCart(int ShoppingcartId)
        {
            List<int> productsid = new List<int>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM CartItem WHERE CartId = @CartId AND ProductId IS NOT NULL";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CartId", ShoppingcartId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["ProductId"]);
                                if (!productsid.Contains(productId))
                                {
                                    productsid.Add(productId);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions
                string errorMessage = $"SQL Exception in GetProductsInCart: {sqlEx.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                string errorMessage = $"Exception in GetProductsInCart: {ex.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
            return productsid;
        }


        public List<int> GetWorkshopsInCart(int ShoppingcartId)
        {
            List<int> workshopsid = new List<int>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM CartItem WHERE CartId = @CartId AND WorkshopId IS NOT NULL";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CartId", ShoppingcartId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int workshopId = Convert.ToInt32(reader["WorkshopId"]);
                                if (!workshopsid.Contains(workshopId))
                                {
                                    workshopsid.Add(workshopId);
                                }

                            }

                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions
                string errorMessage = $"SQL Exception in GetWorkshopsInCart: {sqlEx.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                string errorMessage = $"Exception in GetWorkshopsInCart: {ex.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
            return workshopsid;
        }

    
        

        public void RemoveWorkshopFromCart(int ShoppingCartId, int WorkshopId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Check if the workshop exists in the cart
                    string selectQuery = "SELECT Quantity FROM CartItem WHERE CartId = @CartId AND WorkshopId = @WorkshopId";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@CartId", ShoppingCartId);
                        selectCommand.Parameters.AddWithValue("@WorkshopId", WorkshopId);

                        object existingQuantity = selectCommand.ExecuteScalar();

                        if (existingQuantity != null)
                        {
                            int currentQuantity = (int)existingQuantity;
                            if (currentQuantity > 1) // Decrease quantity if greater than 1
                            {
                                // Update the quantity
                                string updateQuery = "UPDATE CartItem SET Quantity = @Quantity WHERE CartId = @CartId AND WorkshopId = @WorkshopId";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Quantity", currentQuantity - 1);
                                    updateCommand.Parameters.AddWithValue("@CartId", ShoppingCartId);
                                    updateCommand.Parameters.AddWithValue("@WorkshopId", WorkshopId);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                            else // If quantity is 1, remove the workshop
                            {
                                string deleteQuery = "DELETE FROM CartItem WHERE CartId = @CartId AND WorkshopId = @WorkshopId";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@CartId", ShoppingCartId);
                                    deleteCommand.Parameters.AddWithValue("@WorkshopId", WorkshopId);
                                    deleteCommand.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // Handle case where workshop does not exist in the cart
                            throw new WorkshopNotFoundException($"Workshop with ID {WorkshopId} not found in cart {ShoppingCartId}");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions
                string errorMessage = $"SQL Exception in RemoveWorkshopFromCart: {sqlEx.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                string errorMessage = $"Exception in RemoveWorkshopFromCart: {ex.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
        }


        public void RemoveProductFromCart(int ShoppingCartId, int ProductId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Check if the product exists in the cart
                    string selectQuery = "SELECT Quantity FROM CartItem WHERE CartId = @CartId AND ProductId = @ProductId";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@CartId", ShoppingCartId);
                        selectCommand.Parameters.AddWithValue("@ProductId", ProductId);

                        object existingQuantity = selectCommand.ExecuteScalar();

                        if (existingQuantity != null)
                        {
                            int currentQuantity = (int)existingQuantity;
                            if (currentQuantity > 1) // Decrease quantity if greater than 1
                            {
                                // Update the quantity
                                string updateQuery = "UPDATE CartItem SET Quantity = @Quantity WHERE CartId = @CartId AND ProductId = @ProductId";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Quantity", currentQuantity - 1);
                                    updateCommand.Parameters.AddWithValue("@CartId", ShoppingCartId);
                                    updateCommand.Parameters.AddWithValue("@ProductId", ProductId);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                            else // If quantity is 1, remove the product
                            {
                                string deleteQuery = "DELETE FROM CartItem WHERE CartId = @CartId AND ProductId = @ProductId";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@CartId", ShoppingCartId);
                                    deleteCommand.Parameters.AddWithValue("@ProductId", ProductId);
                                    deleteCommand.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // Throw a ProductNotFoundException if the product does not exist in the cart
                            throw new ProductNotFoundException($"Product with ID {ProductId} not found in cart {ShoppingCartId}");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions
                string errorMessage = $"SQL Exception in RemoveProductFromCart: {sqlEx.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                string errorMessage = $"Exception in RemoveProductFromCart: {ex.Message}";
                Console.WriteLine(errorMessage);
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }
        }

        public decimal GetTotalCartAmount(int cartId)
        {
            decimal totalAmount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();
                    string query = @"
                    SELECT 
                        SUM(CASE 
                                WHEN ci.ProductId IS NOT NULL THEN p.Price * ci.Quantity
                                WHEN ci.WorkshopId IS NOT NULL THEN w.Price * ci.Quantity
                            END) AS TotalCartAmount
                    FROM 
                        [dbo].[CartItem] ci
                    LEFT JOIN 
                        [dbo].[Productt] p ON ci.ProductId = p.ProductID
                    LEFT JOIN 
                        [dbo].[Workshopp] w ON ci.WorkshopId = w.WorkshopID
                    WHERE 
                        ci.CartId = @CartId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CartId", cartId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(0))
                            {
                                totalAmount = reader.GetDecimal(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while getting total cart amount.", ex);
            }

            return totalAmount;
        }

      


        public void UpdateUserPoints(int userId, int additionalPoints)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // First, retrieve the current points for the specified user
                    string selectQuery = "SELECT Points FROM dbo.[User] WHERE UserId = @UserId";
                    int currentPoints = 0;

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@UserId", userId);

                        object result = selectCommand.ExecuteScalar();
                        if (result != null)
                        {
                            currentPoints = Convert.ToInt32(result);
                        }
                        else
                        {
                            // Handle the case where the user is not found
                            throw new UserNotFoundException($"User with ID {userId} not found.");
                        }
                    }

                    // Calculate the new points
                    int newPoints = currentPoints + additionalPoints;

                    // Update the user's points in the database
                    string updateQuery = "UPDATE dbo.[User] SET Points = @Points WHERE UserId = @UserId";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Points", newPoints);
                        updateCommand.Parameters.AddWithValue("@UserId", userId);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("Update operation failed.");
                        }
                        // Return true if at least one row was affected (i.e., update was successful)

                    }
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627) // SQL Server error number for unique constraint violation
            {
                // Handle specific SQL Server exceptions
                throw new Exception("SQL Server error occurred while updating points.", sqlEx);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("An error occurred while updating the points.", ex);
            }
        }

        public void RemoveCartItemsByCartId(int cartId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM dbo.CartItem WHERE CartID = @CartID";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CartID", cartId);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Return true if at least one row was affected (i.e., deletion successful)
                       
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new Exception("SQL error occurred while removing cart items by CartID.", sqlEx);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new Exception("An error occurred while removing cart items by CartID.", ex);
            }
        }

        public List<Product> GetCartProductsWithQuantities(int cartId)
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Query to get products from the cart
                    string selectProductQuery = "SELECT p.ProductID, p.ProductName, p.Image, p.Price, p.AmountInStock, i.ItemID, i.BusinessId, i.TypeOfItem, i.Description, c.Quantity " +
                                                "FROM CartItem c " +
                                                "INNER JOIN Productt p ON c.ProductID = p.ProductID " +
                                                "INNER JOIN Item i ON p.ItemID = i.ItemID " +
                                                "WHERE c.CartID = @CartID AND c.ProductID IS NOT NULL";

                    using (SqlCommand productCommand = new SqlCommand(selectProductQuery, connection))
                    {
                        productCommand.Parameters.AddWithValue("@CartID", cartId);

                        using (SqlDataReader productReader = productCommand.ExecuteReader())
                        {
                            while (productReader.Read())
                            {
                                int productId = productReader.GetInt32(productReader.GetOrdinal("ProductID"));
                                string productName = productReader.GetString(productReader.GetOrdinal("ProductName"));
                                string image = productReader.GetString(productReader.GetOrdinal("Image"));
                                decimal price = productReader.GetDecimal(productReader.GetOrdinal("Price"));
                                int amountInStock = productReader.GetInt32(productReader.GetOrdinal("AmountInStock"));
                                string description = productReader.GetString(productReader.GetOrdinal("Description"));
                                int itemId = productReader.GetInt32(productReader.GetOrdinal("ItemID"));
                                int businessId = productReader.GetInt32(productReader.GetOrdinal("BusinessId"));
                                TypeOfItem itemType = (TypeOfItem)productReader.GetInt32(productReader.GetOrdinal("TypeOfItem"));
                                int quantity = productReader.GetInt32(productReader.GetOrdinal("Quantity"));

                                Product product = new Product(productId, itemId, productName, description, image, price, businessId, itemType, amountInStock, quantity);
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler($"SQL error occurred while retrieving cart products with quantities for CartID {cartId}.", sqlEx);
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, re-throwing, etc.)
                throw new Exception("An error occurred while retrieving cart products with quantities.", ex);
            }

            return products;
        }


        public List<Workshop> GetCartWorkshopsWithQuantities(int cartId)
        {
            List<Workshop> workshops = new List<Workshop>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Query to get workshops from the cart
                    string selectWorkshopQuery = "SELECT w.WorkshopID, w.WorkshopName, w.Image, w.Location, w.Price, w.Duration, w.AmountOfPlaces, w.DaysAvailable, i.ItemID, i.BusinessId, i.TypeOfItem, i.Description, c.Quantity " +
                                                 "FROM CartItem c " +
                                                 "INNER JOIN Workshopp w ON c.WorkshopID = w.WorkshopID " +
                                                 "INNER JOIN Item i ON w.ItemID = i.ItemID " +
                                                 "WHERE c.CartID = @CartID AND c.WorkshopID IS NOT NULL";

                    using (SqlCommand workshopCommand = new SqlCommand(selectWorkshopQuery, connection))
                    {
                        workshopCommand.Parameters.AddWithValue("@CartID", cartId);

                        using (SqlDataReader workshopReader = workshopCommand.ExecuteReader())
                        {
                            while (workshopReader.Read())
                            {
                                int workshopId = workshopReader.GetInt32(workshopReader.GetOrdinal("WorkshopID"));
                                string workshopName = workshopReader.GetString(workshopReader.GetOrdinal("WorkshopName"));
                                string description = workshopReader.GetString(workshopReader.GetOrdinal("Description"));
                                string image = workshopReader.GetString(workshopReader.GetOrdinal("Image"));
                                string location = workshopReader.GetString(workshopReader.GetOrdinal("Location"));
                                decimal price = workshopReader.GetDecimal(workshopReader.GetOrdinal("Price"));
                                int amountOfPlaces = workshopReader.GetInt32(workshopReader.GetOrdinal("AmountOfPlaces"));
                                string daysAvailable = workshopReader.GetString(workshopReader.GetOrdinal("DaysAvailable"));
                                int itemId = workshopReader.GetInt32(workshopReader.GetOrdinal("ItemID"));
                                int businessId = workshopReader.GetInt32(workshopReader.GetOrdinal("BusinessId"));
                                TypeOfItem itemType = (TypeOfItem)workshopReader.GetInt32(workshopReader.GetOrdinal("TypeOfItem"));
                                DurationType duration = (DurationType)workshopReader.GetInt32(workshopReader.GetOrdinal("Duration"));
                                int quantity = workshopReader.GetInt32(workshopReader.GetOrdinal("Quantity"));

                                Workshop workshop = new Workshop(workshopId, itemId, workshopName, description, image, location, price, amountOfPlaces, daysAvailable, businessId, itemType, duration, quantity);
                                workshops.Add(workshop);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler($"SQL error occurred while retrieving cart workshops with quantities for CartID {cartId}.", sqlEx);
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, re-throwing, etc.)
                throw new Exception("An error occurred while retrieving cart workshops with quantities.", ex);
            }

            return workshops;
        }


    }
}









