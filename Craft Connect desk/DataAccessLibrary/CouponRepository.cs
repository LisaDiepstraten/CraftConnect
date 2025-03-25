using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class CouponRepository : ICouponRepository
    {
        Connection connectionstring = new Connection();

        public List<Coupon> GetAllTheCoupons()
        {
            List<Coupon> coupons = new List<Coupon>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM Coupon";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int CouponID = Convert.ToInt32(reader["Id"]);
                                DiscountType DiscountType = ((DiscountType)reader["DiscountType"]);
                                string Name = reader["Name"].ToString();
                                string Description = reader["Description"].ToString();
                                DateTime expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                decimal percentage = Convert.ToDecimal(reader["Percentage"]);

                                Coupon coup = new Coupon(CouponID, DiscountType, Name, Description, expirationDate, percentage );

                                coupons.Add(coup);
                            }
                        }
                    }
                }
               
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseExceptionHandler("SQL error occurred while getting all the coupons.", sqlEx);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new DatabaseExceptionHandler("An error occurred while getting all the coupons.", ex);
            }
            return coupons;
        }


        public int GetDistinctBusinessCount(int cartId)
        {
            int distinctBusinessCount = 0;
            string query = @"
        -- Get the BusinessId for Products in the Cart
        WITH ProductBusiness AS (
            SELECT DISTINCT i.BusinessId
            FROM [dbi523722_craftconn].[dbo].[CartItem] ci
            JOIN [dbi523722_craftconn].[dbo].[Productt] p ON ci.ProductId = p.ProductID
            JOIN [dbi523722_craftconn].[dbo].[Item] i ON p.ItemID = i.ItemID
            WHERE ci.CartId = @CartId
        ),
        -- Get the BusinessId for Workshops in the Cart
        WorkshopBusiness AS (
            SELECT DISTINCT i.BusinessId
            FROM [dbi523722_craftconn].[dbo].[CartItem] ci
            JOIN [dbi523722_craftconn].[dbo].[Workshopp] w ON ci.WorkshopId = w.WorkshopID
            JOIN [dbi523722_craftconn].[dbo].[Item] i ON w.ItemID = i.ItemID
            WHERE ci.CartId = @CartId
        )
        -- Combine both and count distinct BusinessIds
        SELECT COUNT(DISTINCT BusinessId) AS DistinctBusinessCount
        FROM (
            SELECT BusinessId FROM ProductBusiness
            UNION
            SELECT BusinessId FROM WorkshopBusiness
        ) AS CombinedBusiness;
    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the parameter to the command
                        command.Parameters.AddWithValue("@CartId", cartId);

                        connection.Open();
                        // Execute the query and get the count
                        distinctBusinessCount = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler("SQL error occurred while getting distinct business count.", sqlEx);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new DatabaseExceptionHandler("An error occurred while getting distinct business count.", ex);
            }

            return distinctBusinessCount;
        }



        public decimal GetTotalPriceOfMostCommonItemType(int cartID)
        {
            decimal totalPrice = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Get the most common ItemType in the shopping cart
                    string itemTypeQuery = @"
                SELECT TOP 1 ItemType, COUNT(*) as Quantity
                FROM (
                    SELECT 'Product' as ItemType FROM CartItem WHERE CartID = @CartID AND ProductId IS NOT NULL
                    UNION ALL
                    SELECT 'Workshop' as ItemType FROM CartItem WHERE CartID = @CartID AND WorkshopId IS NOT NULL
                ) as CartItems
                GROUP BY ItemType
                ORDER BY Quantity DESC";

                    string mostCommonItemType = null;

                    using (SqlCommand itemTypeCommand = new SqlCommand(itemTypeQuery, connection))
                    {
                        itemTypeCommand.Parameters.AddWithValue("@CartID", cartID);
                        using (SqlDataReader reader = itemTypeCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mostCommonItemType = reader.GetString(0);
                            }
                        }
                    }

                    if (mostCommonItemType != null)
                    {
                        // Calculate the total price of products and workshops of the most common ItemType
                        string totalPriceQuery = @"
                    SELECT SUM(Price * Quantity) as TotalPrice
                    FROM (
                        SELECT p.Price, ci.Quantity
                        FROM [dbi523722_craftconn].[dbo].[Productt] p
                        JOIN [dbi523722_craftconn].[dbo].[CartItem] ci ON p.ProductID = ci.ProductId
                        WHERE ci.CartID = @CartID AND @itemType = 'Product'
                        UNION ALL
                        SELECT w.Price, ci.Quantity
                        FROM [dbi523722_craftconn].[dbo].[Workshopp] w
                        JOIN [dbi523722_craftconn].[dbo].[CartItem] ci ON w.WorkshopID = ci.WorkshopId
                        WHERE ci.CartID = @CartID AND @itemType = 'Workshop'
                    ) as TotalPriceQuery";

                        using (SqlCommand totalPriceCommand = new SqlCommand(totalPriceQuery, connection))
                        {
                            totalPriceCommand.Parameters.AddWithValue("@CartID", cartID);
                            totalPriceCommand.Parameters.AddWithValue("@itemType", mostCommonItemType);
                            using (SqlDataReader totalReader = totalPriceCommand.ExecuteReader())
                            {
                                if (totalReader.Read())
                                {
                                    totalPrice = totalReader.IsDBNull(0) ? 0 : totalReader.GetDecimal(0);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler("SQL error occurred while calculating the total price of the most common item type.", sqlEx);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new DatabaseExceptionHandler("An error occurred while calculating the total price of the most common item type.", ex);
            }

            return totalPrice;
        }



        public int GetHighestCountOfItemType(int cartId)
        {
            int highestCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    // Get the highest count of any ItemType in the shopping cart
                    string itemTypeCountQuery = @"
            SELECT TOP 1 COUNT(*) as Quantity
            FROM (
                SELECT ProductId, 'Product' as ItemType FROM CartItem
                WHERE CartId = @cartId
                UNION ALL
                SELECT WorkshopId, 'Workshop' as ItemType FROM CartItem
                WHERE CartId = @cartId
            ) as CartItems
            GROUP BY ItemType
            ORDER BY Quantity DESC";

                    using (SqlCommand itemTypeCountCommand = new SqlCommand(itemTypeCountQuery, connection))
                    {
                        itemTypeCountCommand.Parameters.AddWithValue("@cartId", cartId);
                        using (SqlDataReader reader = itemTypeCountCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                highestCount = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler("SQL error occurred while getting the highest count of item types.", sqlEx);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new DatabaseExceptionHandler("An error occurred while getting the highest count of item types.", ex);
            }

            return highestCount;
        }


        
        public decimal GetDiscountPercentage(int couponId)
        {
            decimal discountPercentage = 0;

            try
            {
                string sqlQuery = "SELECT [Percentage] FROM [Coupon] WHERE [Id] = @CouponId";

                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@CouponId", couponId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        discountPercentage = Convert.ToDecimal(result);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseExceptionHandler("SQL error occurred while retrieving discount percentage for coupon.", sqlEx);
            }
            catch (CouponNotFoundException cnfEx)
            {
                throw cnfEx;  // Re-throw to be caught by the logic layer
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while retrieving discount percentage for coupon.", ex);
            }


            return discountPercentage;
        }


        public bool AddCoupon(Coupon coupon)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO [dbi523722_craftconn].[dbo].[Coupon] " +
                                         "([DiscountType], [Name], [Description], [ExpirationDate], [Percentage]) " +
                                         "VALUES (@DiscountType, @Name, @Description, @ExpirationDate, @Percentage)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DiscountType", (int)coupon.DiscountType);
                        command.Parameters.AddWithValue("@Name", coupon.Name);
                        command.Parameters.AddWithValue("@Description", coupon.Description);
                        command.Parameters.AddWithValue("@ExpirationDate", coupon.ExpirationDate);
                        command.Parameters.AddWithValue("@Percentage", coupon.Percentage);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the insert was successful
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseExceptionHandler("SQL error occurred while adding a coupon.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while adding a coupon.", ex);
            }
        }

        public Coupon GetCouponById(int id)
        {
            Coupon coupon = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string selectQuery = "SELECT [Id], [DiscountType], [Name], [Description], [ExpirationDate], [Percentage] " +
                                         "FROM [dbi523722_craftconn].[dbo].[Coupon] " +
                                         "WHERE [Id] = @Id";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int couponId = Convert.ToInt32(reader["Id"]);
                                DiscountType discountTypeValue = (DiscountType)Convert.ToInt32(reader["DiscountType"]);
                                string name = reader["Name"].ToString();
                                string description = reader["Description"].ToString();
                                DateTime expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                decimal percentage = Convert.ToDecimal(reader["Percentage"]);

                                coupon = new Coupon(
                                    couponId,
                                    discountTypeValue,
                                    name,
                                    description,
                                    expirationDate,
                                    percentage
                                );
                            }
                            else
                            {
                                throw new CouponNotFoundException($"Coupon with ID {id} not found.");
                            }
                        }
                    }
                }
                return coupon;
            }
            catch (CouponNotFoundException)
            {
                throw; // Re-throwing to propagate up
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseExceptionHandler("SQL error occurred while getting the coupon by ID.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while getting the coupon by ID.", ex);
            }
        }

        public bool UpdateCoupon(Coupon coupon)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring.GetConnection()))
                {
                    connection.Open();

                    string updateQuery = "UPDATE [dbi523722_craftconn].[dbo].[Coupon] " +
                                         "SET [DiscountType] = @DiscountType, " +
                                         "[Name] = @Name, " +
                                         "[Description] = @Description, " +
                                         "[ExpirationDate] = @ExpirationDate, " +
                                         "[Percentage] = @Percentage " +
                                         "WHERE [Id] = @Id";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DiscountType", (int)coupon.DiscountType);
                        command.Parameters.AddWithValue("@Name", coupon.Name);
                        command.Parameters.AddWithValue("@Description", coupon.Description);
                        command.Parameters.AddWithValue("@ExpirationDate", coupon.ExpirationDate);
                        command.Parameters.AddWithValue("@Percentage", coupon.Percentage);
                        command.Parameters.AddWithValue("@Id", coupon.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the update was successful
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseExceptionHandler("SQL error occurred while updating the coupon.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new DatabaseExceptionHandler("An error occurred while updating the coupon.", ex);
            }
        }
    }

}

