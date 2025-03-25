using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class ItemRepository : IItemRepository   // add try and catch blocks
    {
        //public List<Item> GetItems() { }
        Connection connectionstring = new Connection();


        public bool CreateItem(Item item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Start a transaction
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Insert into Item table
                        string insertItemQuery = @"
                    INSERT INTO Item (Description, BusinessId, TypeOfItem) 
                    OUTPUT INSERTED.ItemID
                    VALUES (@Description, @BusinessId, @TypeOfItem)";

                        int itemId;
                        using (SqlCommand command = new SqlCommand(insertItemQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Description", item.Description);
                            command.Parameters.AddWithValue("@BusinessId", item.BusinessId);
                            command.Parameters.AddWithValue("@TypeOfItem", (int)item.TypeOfItem);

                            // Execute the query and get the inserted ItemID
                            itemId = (int)command.ExecuteScalar();
                        }

                        // Determine if the item is a Product or Workshop and insert into the respective table
                        if (item is Product product)
                        {
                            string insertProductQuery = @"
                        INSERT INTO Productt (ProductName, Image, Price, AmountInStock, ItemID) 
                        VALUES (@ProductName, @Image, @Price, @AmountInStock, @ItemID)";

                            using (SqlCommand command = new SqlCommand(insertProductQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                                command.Parameters.AddWithValue("@Image", product.Image ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Price", product.Price);
                                command.Parameters.AddWithValue("@AmountInStock", product.AmountInStock);
                                command.Parameters.AddWithValue("@ItemID", itemId);

                                command.ExecuteNonQuery();
                            }
                        }
                        else if (item is Workshop workshop)
                        {
                            string insertWorkshopQuery = @"
                        INSERT INTO Workshopp (WorkshopName, Image, Location, Price, AmountOfPlaces, DaysAvailable, Duration, ItemID) 
                        VALUES (@WorkshopName, @Image, @Location, @Price, @AmountOfPlaces, @DaysAvailable, @Duration, @ItemID)";

                            using (SqlCommand command = new SqlCommand(insertWorkshopQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@WorkshopName", workshop.WorkshopName);
                                command.Parameters.AddWithValue("@Image", workshop.Image ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Location", workshop.Location);
                                command.Parameters.AddWithValue("@Price", workshop.Price);
                                command.Parameters.AddWithValue("@AmountOfPlaces", workshop.AmountOfPlaces);
                                command.Parameters.AddWithValue("@DaysAvailable", workshop.DaysAvailable);
                                command.Parameters.AddWithValue("@Duration", (int)workshop.Duration);
                                command.Parameters.AddWithValue("@ItemID", itemId);

                                command.ExecuteNonQuery();
                            }
                        }

                        // Commit the transaction
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction if there is an error
                        transaction.Rollback();
                        throw new DatabaseExceptionHandler("An error occurred while adding the item.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new DatabaseExceptionHandler("An error occurred while adding the item.", ex);
            }
        }



        public List<Workshop> GetWorkshopsByBusinessId(int businessId)
        {
            List<Workshop> workshopList = new List<Workshop>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = @"
                SELECT 
                    w.WorkshopID, 
                    w.WorkshopName, 
                    i.Description, 
                    w.Image, 
                    w.Location, 
                    w.Price, 
                    w.AmountOfPlaces, 
                    w.DaysAvailable, 
                    i.BusinessId, 
                    i.TypeOfItem, 
                    w.Duration, 
                    w.ItemID 
                FROM 
                    Workshopp w
                JOIN 
                    Item i ON w.ItemID = i.ItemID
                WHERE 
                    i.BusinessId = @BusinessId";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BusinessId", businessId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int workshopId = reader.GetInt32(reader.GetOrdinal("WorkshopID"));
                                string workshopName = reader.GetString(reader.GetOrdinal("WorkshopName"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));
                                string image = reader.GetString(reader.GetOrdinal("Image"));
                                string location = reader.GetString(reader.GetOrdinal("Location"));
                                decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                                int amountOfPlaces = reader.GetInt32(reader.GetOrdinal("AmountOfPlaces"));
                                string daysAvailable = reader.GetString(reader.GetOrdinal("DaysAvailable"));
                                TypeOfItem itemType = (TypeOfItem)reader.GetInt32(reader.GetOrdinal("TypeOfItem"));
                                DurationType duration = (DurationType)reader.GetInt32(reader.GetOrdinal("Duration"));
                                int itemId = reader.GetInt32(reader.GetOrdinal("ItemID"));

                                Workshop workshop = new Workshop(workshopId, itemId, workshopName, description, image, location, price, amountOfPlaces, daysAvailable, businessId, itemType, duration);
                                workshopList.Add(workshop);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while retrieving workshops by business ID.", ex);
            }
            return workshopList;
        }




        public List<Workshop> GetAllWorkshops()
        {
            List<Workshop> workshopList = new List<Workshop>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = @"
                SELECT 
                    w.WorkshopID, w.WorkshopName, w.Image, w.Location, 
                    w.Price, w.AmountOfPlaces, w.DaysAvailable, w.ItemID, w.Duration, 
                    i.Description AS ItemDescription, i.BusinessId, i.TypeOfItem
                FROM 
                    Workshopp w 
                INNER JOIN 
                    Item i ON w.ItemID = i.ItemID";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Map data from the reader to a new Workshop object
                                int workshopId = reader.GetInt32(reader.GetOrdinal("WorkshopID"));
                                string workshopName = reader.GetString(reader.GetOrdinal("WorkshopName"));
                                string description = reader["ItemDescription"].ToString();
                                string image = reader.GetString(reader.GetOrdinal("Image"));
                                string location = reader.GetString(reader.GetOrdinal("Location"));
                                decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                                int amountOfPlaces = reader.GetInt32(reader.GetOrdinal("AmountOfPlaces"));
                                string daysAvailable = reader.GetString(reader.GetOrdinal("DaysAvailable"));
                                int businessId = reader.GetInt32(reader.GetOrdinal("BusinessId"));
                                TypeOfItem itemType = (TypeOfItem)reader.GetInt32(reader.GetOrdinal("TypeOfItem"));
                                DurationType duration = (DurationType)reader.GetInt32(reader.GetOrdinal("Duration"));
                                int itemId = reader.GetInt32(reader.GetOrdinal("ItemID"));

                                Workshop workshop = new Workshop(workshopId, itemId, workshopName, description, image, location, price, amountOfPlaces, daysAvailable, businessId, itemType, duration);
                                workshopList.Add(workshop);
                            }
                        }
                    }
                }
                return workshopList;
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while retrieving all workshops.", ex);
            }
        }


        public bool RemoveWorkshop(int workshopId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Get the ItemId associated with the workshop
                    string getItemIdQuery = "SELECT ItemID FROM dbo.Workshopp WHERE WorkshopID = @WorkshopID";

                    int itemId;
                    using (SqlCommand itemIdCommand = new SqlCommand(getItemIdQuery, connection))
                    {
                        itemIdCommand.Parameters.AddWithValue("@WorkshopID", workshopId);
                        itemId = Convert.ToInt32(itemIdCommand.ExecuteScalar());
                    }

                    // Delete the workshop
                    string deleteWorkshopQuery = "DELETE FROM dbo.Workshopp WHERE WorkshopID = @WorkshopID";
                    using (SqlCommand deleteWorkshopCommand = new SqlCommand(deleteWorkshopQuery, connection))
                    {
                        deleteWorkshopCommand.Parameters.AddWithValue("@WorkshopID", workshopId);
                        deleteWorkshopCommand.ExecuteNonQuery();
                    }

                    // Delete the associated item
                    string deleteItemQuery = "DELETE FROM dbo.Item WHERE ItemID = @ItemID";
                    using (SqlCommand deleteItemCommand = new SqlCommand(deleteItemQuery, connection))
                    {
                        deleteItemCommand.Parameters.AddWithValue("@ItemID", itemId);
                        deleteItemCommand.ExecuteNonQuery();
                    }

                    return true; // Successfully deleted workshop and associated item
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while removing the workshop in the DAL.", ex);
            }
        }



        public List<Product> GetProductsByBusinessId(int businessId)
        {
            List<Product> productList = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = @"
                SELECT 
                    p.ProductID, 
                    p.ProductName, 
                    i.Description, 
                    p.Image, 
                    p.Price, 
                    p.AmountInStock, 
                    i.TypeOfItem, 
                    p.ItemID 
                FROM 
                    Productt p
                JOIN 
                    Item i ON p.ItemID = i.ItemID
                WHERE 
                    i.BusinessId = @BusinessId";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BusinessId", businessId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["ProductID"]);
                                string productName = reader["ProductName"].ToString();
                                string description = reader["Description"].ToString();
                                string image = reader["Image"].ToString();
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int amountInStock = Convert.ToInt32(reader["AmountInStock"]);
                                TypeOfItem itemType = (TypeOfItem)Convert.ToInt32(reader["TypeOfItem"]);
                                int itemId = Convert.ToInt32(reader["ItemID"]);

                                Product product = new Product(productId, itemId, productName, description, image, price, businessId, itemType, amountInStock);

                                productList.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while getting the products by business ID in the DAL.", ex);
            }

            return productList;
        }


        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = @"
                SELECT 
                    p.ProductID, p.ProductName, p.Image, p.Price, p.AmountInStock, 
                    i.ItemID, i.BusinessId, i.TypeOfItem, i.Description
                FROM 
                    Productt p 
                INNER JOIN 
                    Item i ON p.ItemID = i.ItemID";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["ProductID"]);
                                string productName = reader["ProductName"].ToString();
                                string description = reader["Description"].ToString(); // Description from the Item table
                                string image = reader["Image"].ToString();
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                TypeOfItem itemType = (TypeOfItem)reader.GetInt32(reader.GetOrdinal("TypeOfItem"));
                                int amountInStock = Convert.ToInt32(reader["AmountInStock"]);
                                int businessId = Convert.ToInt32(reader["BusinessId"]);
                                int itemId = Convert.ToInt32(reader["ItemID"]);

                                Product product = new Product(productId, itemId, productName, description, image, price, businessId, itemType, amountInStock);

                                productList.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while getting all products in the DAL.", ex);
            }


            return productList;
        }


        public bool RemoveProduct(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Begin a transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Delete the product from the Productt table
                        string deleteProductQuery = "DELETE FROM Productt WHERE ProductID = @ProductId";
                        using (SqlCommand command = new SqlCommand(deleteProductQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ProductId", productId);
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected == 0)
                            {
                                // If no rows were affected, rollback the transaction and return false
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // Delete the corresponding item from the Item table
                        string deleteItemQuery = "DELETE FROM Item WHERE ItemID = @ItemId";
                        using (SqlCommand command = new SqlCommand(deleteItemQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ItemId", productId); // Assuming productId is also the ItemID
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected == 0)
                            {
                                // If no rows were affected, rollback the transaction and return false
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // If all deletions were successful, commit the transaction
                        transaction.Commit();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new DatabaseExceptionHandler("An error occurred while removing the product in the DAL.", ex);
            }
        }

        public bool UpdateItem(Item item)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    int? itemId = null; // Initialize itemId as nullable

                    if (item is Product product)
                    {
                        // Update the product in the Productt table
                        string updateProductQuery = "UPDATE dbo.Productt SET ProductName = @ProductName, Image = @Image, Price = @Price, AmountInStock = @AmountInStock WHERE ProductID = @ProductId";
                        using (SqlCommand command = new SqlCommand(updateProductQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ProductName", product.ProductName);
                            command.Parameters.AddWithValue("@Image", product.Image);
                            command.Parameters.AddWithValue("@Price", product.Price);
                            command.Parameters.AddWithValue("@AmountInStock", product.AmountInStock);
                            command.Parameters.AddWithValue("@ProductId", product.ProductID);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                return false; // If no rows were updated, return false
                            }
                        }

                        // Retrieve itemId from the product
                        itemId = product.Id;
                    }
                    else if (item is Workshop workshop)
                    {
                        // Update the workshop in the Workshopp table
                        string updateWorkshopQuery = "UPDATE dbo.Workshopp SET WorkshopName = @WorkshopName, Image = @Image, Location = @Location, Price = @Price, Duration = @Duration, AmountOfPlaces = @AmountOfPlaces, DaysAvailable = @DaysAvailable WHERE WorkshopID = @WorkshopId";
                        using (SqlCommand command = new SqlCommand(updateWorkshopQuery, connection))
                        {
                            command.Parameters.AddWithValue("@WorkshopName", workshop.WorkshopName);
                            command.Parameters.AddWithValue("@Image", workshop.Image);
                            command.Parameters.AddWithValue("@Location", workshop.Location);
                            command.Parameters.AddWithValue("@Price", workshop.Price);
                            command.Parameters.AddWithValue("@Duration", workshop.Duration);
                            command.Parameters.AddWithValue("@AmountOfPlaces", workshop.AmountOfPlaces);
                            command.Parameters.AddWithValue("@DaysAvailable", workshop.DaysAvailable);
                            command.Parameters.AddWithValue("@WorkshopId", workshop.WorkshopId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                return false; // If no rows were updated, return false
                            }
                        }

                        // Retrieve itemId from the workshop
                        itemId = workshop.Id;
                    }

                    if (itemId.HasValue)
                    {
                        // Update common item fields (Description, BusinessId, TypeOfItem) in the Item table
                        string updateItemQuery = "UPDATE dbo.Item SET Description = @Description, BusinessId = @BusinessId, TypeOfItem = @TypeOfItem WHERE ItemID = @ItemId";
                        using (SqlCommand command = new SqlCommand(updateItemQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Description", item.Description);
                            command.Parameters.AddWithValue("@BusinessId", item.BusinessId);
                            command.Parameters.AddWithValue("@TypeOfItem", (int)item.TypeOfItem);
                            command.Parameters.AddWithValue("@ItemId", itemId.Value); // Use the itemId obtained from the workshop or product

                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                    else
                    {
                        // itemId is null, so cannot update the Item table
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                throw new DatabaseExceptionHandler("An error occurred while updating the item in the DAL.", ex);
            }
        }


        public Workshop GetWorkshopById(int workshopId)
        {
            Workshop workshop = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = @"
                SELECT 
                    w.WorkshopID, w.WorkshopName, w.Image, w.Location, 
                    w.Price, w.AmountOfPlaces, w.DaysAvailable, w.ItemID, w.Duration, 
                    i.TypeOfItem, i.BusinessId, i.Description AS ItemDescription 
                FROM 
                    Workshopp w 
                INNER JOIN 
                    Item i ON w.ItemID = i.ItemID 
                WHERE 
                    w.WorkshopID = @WorkshopId";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@WorkshopId", workshopId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Map data from the reader to a new Workshop object
                                int id = Convert.ToInt32(reader["WorkshopID"]);
                                string workshopName = reader["WorkshopName"].ToString();
                                string image = reader["Image"].ToString();
                                string location = reader["Location"].ToString();
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int amountOfPlaces = Convert.ToInt32(reader["AmountOfPlaces"]);
                                string daysAvailable = reader["DaysAvailable"].ToString();
                                int itemId = Convert.ToInt32(reader["ItemID"]);
                                string itemDescription = reader["ItemDescription"].ToString();
                                int businessId = Convert.ToInt32(reader["BusinessId"]);
                                TypeOfItem type = (TypeOfItem)reader["TypeOfItem"];
                                DurationType duration = (DurationType)reader["Duration"];

                                // Create Item object
                                Item item = new Item(itemId, itemDescription, businessId, type);

                                // Create Workshop object with Item
                                workshop = new Workshop(id, itemId, workshopName, itemDescription, image, location, price, amountOfPlaces, daysAvailable, businessId, type, duration);
                                return workshop;
                            }
                        }
                    }
                }
                if (workshop == null)
                {
                    throw new WorkshopNotFoundException($"Workshop with ID {workshopId} not found in the database.");
                }

                return workshop;
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseExceptionHandler("A SQL-related error occurred while getting the workshop by ID in the DAL.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while getting the workshop by ID in the DAL.", ex);
            }
        }


        // Return null if no workshop is found





        public Product GetProductByIdP(int productId)
        {
            Product product = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = @"
                SELECT 
                    p.ProductID, p.ProductName, p.Image, 
                    p.Price, p.AmountInStock, p.ItemID, 
                    i.TypeOfItem, i.BusinessId, i.Description AS ItemDescription 
                FROM 
                    Productt p 
                INNER JOIN 
                    Item i ON p.ItemID = i.ItemID 
                WHERE 
                    p.ProductID = @ProductId";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Map data from the reader to a new Product object
                                int id = Convert.ToInt32(reader["ProductID"]);
                                string productName = reader["ProductName"].ToString();
                                string image = reader["Image"].ToString();
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int amountInStock = Convert.ToInt32(reader["AmountInStock"]);
                                int itemId = Convert.ToInt32(reader["ItemID"]);
                                string itemDescription = reader["ItemDescription"].ToString();
                                int businessId = Convert.ToInt32(reader["BusinessId"]);
                                TypeOfItem type = (TypeOfItem)reader["TypeOfItem"];

                                // Create Item object
                                Item item = new Item(itemId, itemDescription, businessId, type);

                                // Create Product object with Item
                                 product = new Product(id, itemId, productName, itemDescription, image, price, businessId, type, amountInStock);
                                return product;
                            }
                        }
                    }
                }
                if (product == null)
                {
                    throw new ProductNotFoundException($"Product with ID {productId} not found in the database.");
                }

                return product;
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseExceptionHandler("A SQL-related error occurred while getting the product by ID in the DAL.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while getting the product by ID in the DAL.", ex);
            }
        }


        public void DecreaseStockForCartP(int cartId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // First, read all products and quantities from the CartItem table
                    string selectQuery = "SELECT ProductID, Quantity FROM dbo.CartItem WHERE CartID = @CartID AND ProductID IS NOT NULL";
                    List<(int ProductID, int Quantity)> productsToUpdate = new List<(int ProductID, int Quantity)>();

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CartID", cartId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = reader.IsDBNull(reader.GetOrdinal("ProductID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProductID"));
                                int quantity = reader.IsDBNull(reader.GetOrdinal("Quantity")) ? 0 : reader.GetInt32(reader.GetOrdinal("Quantity"));

                                if (productId != 0 && quantity != 0)
                                {
                                    productsToUpdate.Add((productId, quantity));
                                }
                            }
                        }
                    }

                    // Then, update the stock for each product
                    foreach ((int ProductID, int Quantity) in productsToUpdate)
                    {
                        string updateQuery = "UPDATE dbo.Productt SET AmountInStock = AmountInStock - @Quantity WHERE ProductID = @ProductID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Quantity", Quantity);
                            updateCommand.Parameters.AddWithValue("@ProductID", ProductID);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {

                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while decreasing stock of cart Products DAL.", ex);
            }
        }

        public void DecreaseStockForCartW(int cartId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // First, read all workshops and quantities from the CartItem table
                    string selectQuery = "SELECT WorkshopID, Quantity FROM dbo.CartItem WHERE CartID = @CartID AND WorkshopID IS NOT NULL";
                    List<(int WorkshopID, int Quantity)> workshopsToUpdate = new List<(int WorkshopID, int Quantity)>();

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CartID", cartId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int workshopId = reader.IsDBNull(reader.GetOrdinal("WorkshopID")) ? 0 : reader.GetInt32(reader.GetOrdinal("WorkshopID"));
                                int quantity = reader.IsDBNull(reader.GetOrdinal("Quantity")) ? 0 : reader.GetInt32(reader.GetOrdinal("Quantity"));

                                if (workshopId != 0 && quantity != 0)
                                {
                                    workshopsToUpdate.Add((workshopId, quantity));
                                }
                            }
                        }
                    }

                    // Then, update the stock for each workshop
                    foreach ((int WorkshopID, int Quantity) in workshopsToUpdate)
                    {
                        string updateQuery = "UPDATE dbo.Workshopp SET AmountOfPlaces = AmountOfPlaces - @Quantity WHERE WorkshopID = @WorkshopID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Quantity", Quantity);
                            updateCommand.Parameters.AddWithValue("@WorkshopID", WorkshopID);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                // Handle case where update did not affect any rows
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while decreasing stock of cart Workshops DAL.", ex);
            }
        }







        public List<Product> GetProductsByPagination(int pageNumber)
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring.GetConnection()))
                {
                    int itemsPerPage = 25;
                    int offset = (pageNumber - 1) * itemsPerPage;

                    string query = @"
                SELECT
                    p.ProductID, p.ProductName, p.Image, p.Price, p.AmountInStock, p.ItemID,
                    i.Description AS ItemDescription, i.BusinessId, i.TypeOfItem
                FROM 
                    Productt p
                INNER JOIN
                    Item i ON p.ItemID = i.ItemID
                ORDER BY 
                    p.ItemID
                OFFSET 
                    @Offset ROWS FETCH NEXT 
                    @ItemsPerPage ROWS ONLY";

                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Offset", offset);
                        cmd.Parameters.AddWithValue("@ItemsPerPage", itemsPerPage);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int productId = Convert.ToInt32(reader["ProductID"]);
                            string productName = reader["ProductName"].ToString();
                            string image = reader["Image"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            int amountInStock = Convert.ToInt32(reader["AmountInStock"]);
                            int itemId = Convert.ToInt32(reader["ItemID"]);
                            string itemDescription = reader["ItemDescription"].ToString();
                            int businessId = Convert.ToInt32(reader["BusinessId"]);
                            TypeOfItem type = (TypeOfItem)reader["TypeOfItem"];

                            // Create Item object
                            Item item = new Item(itemId, itemDescription, businessId, type);

                            // Create Product object with Item
                            Product product = new Product(productId, itemId, productName, itemDescription, image, price, businessId, type, amountInStock);

                            products.Add(product);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL specific exceptions or log them
                throw new DatabaseExceptionHandler("An error occurred in SQL execution.", sqlEx);
            }
            catch (Exception ex)
            {
                // Handle other general exceptions or log them
                throw new DatabaseExceptionHandler("An error occurred in data access layer.", ex);
            }
            return products;
        }

    }
}



