using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Services
{
    public class CartService 
    {
        private ICartRepository carts;


        public CartService(ICartRepository carts)
        {
           
           this.carts = carts;
        }



        public bool InsertWorkshopToCart(int shoppingcartId, int workshopId)
        {
            try
            {
                if (shoppingcartId != 0 && workshopId != 0)
                {
                    carts.AddWorkshopToCart(shoppingcartId, workshopId);
                    return true;
                }
                else
                {
                    throw new ArgumentException("Shopping cart ID and workshop ID must be greater than 0.");

                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while adding the workshop to cart.", ex);
            }
        }

        public bool InsertProductToCart(int ShoppingcartId, int productid)  
        {
            try
            {
                if (ShoppingcartId <= 0 || productid <= 0)
                {
                    throw new ArgumentException("Shopping cart ID and product ID must be greater than 0.");
                }
               
                    carts.AddProductToCart(ShoppingcartId, productid);
                    return true;
                
                
            }
            catch (ArgumentException)
            {
               
                throw;
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while adding the product to cart.", ex);
            }
            
        }

        public List<int> GetIDsFromCartP(int ShoppingcartId)
        {
            List<int> ids = new List<int>();
            try
            {
                if (ShoppingcartId <= 0)
                {
                    throw new ArgumentException("Shopping cart ID must be greater than 0.");
                }
                ids = carts.GetProductsInCart(ShoppingcartId);
                // Cart.AddWorkshopToCart(ShoppingcartId, workshopid);
               return ids;
            }
            catch (ArgumentException)
            {
                
                throw;
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while getting product IDs from cart.", ex);
            }
        }

        public List<int> GetIDsFromCartW(int ShoppingcartId)
        {
            List<int> ids = new List<int>();
            try
            {
                if (ShoppingcartId <= 0)
                {
                    throw new ArgumentException("Shopping cart ID must be greater than 0.");
                }
                ids = carts.GetWorkshopsInCart(ShoppingcartId);
                // Cart.AddWorkshopToCart(ShoppingcartId, workshopid);
                return ids;
            }
            catch (ArgumentException)
            {
                
                throw;
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while getting workshop IDs from cart.", ex);
            }

        }

        

        public void RemoveWorkshopCart(int ShoppingCartId, int WorkshopId)
        {
            try
            {
                carts.RemoveWorkshopFromCart(ShoppingCartId, WorkshopId);

                
            }
            catch (SqlException sqlEx)
            {
                // Wrap and throw SQL-related exceptions as DatabaseExceptionHandler
                string errorMessage = $"SQL Exception occurred in RemoveWorkshopCart: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                // Wrap and throw other exceptions as DatabaseExceptionHandler
                string errorMessage = $"Exception occurred in RemoveWorkshopCart: {ex.Message}";
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }

        }

        public void RemoveProductCart(int ShoppingCartId, int ProductId)
        {
            try
            {
                carts.RemoveProductFromCart(ShoppingCartId, ProductId);


            }
            catch (ProductNotFoundException)
            {
                 throw;
            }
            catch (SqlException sqlEx)
            {
                 string errorMessage = $"SQL Exception occurred in RemoveProductCart: {sqlEx.Message}";
                throw new DatabaseExceptionHandler(errorMessage, sqlEx);
            }
            catch (Exception ex)
            {
                 string errorMessage = $"Exception occurred in RemoveProductCart: {ex.Message}";
                throw new DatabaseExceptionHandler(errorMessage, ex);
            }

        }

        public decimal GetTotalOfCart(int ShoppingCartId)
        {
            try
            {
                if (ShoppingCartId != 0)
                {
                    return carts.GetTotalCartAmount(ShoppingCartId);
                }
                throw new ArgumentException("Shopping cart ID must be greater than 0.");
            }
            catch (Exception ex)
            {
                
                string errorMessage = $"An error occurred while getting total cart amount for cart ID {ShoppingCartId}.";
                throw new Exception(errorMessage, ex);
            }
        }

        public void SetPointsUser(decimal carttotal, int userId)
        {
            try
            {
                int points = (int)Math.Ceiling(carttotal);
                carts.UpdateUserPoints(userId, points);
            }
            catch (Exception ex)
            {
                
                string errorMessage = $"An error occurred while setting points for user ID {userId}: {ex.Message}";
                throw new Exception(errorMessage, ex);
            }
        }

        public void EmptyCart(int ShoppingCartId)
        {
            try
            {
                carts.RemoveCartItemsByCartId(ShoppingCartId);
                
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler($"SQL error occurred while emptying cart {ShoppingCartId}: {sqlEx.Message}", sqlEx);
            }
            catch (Exception ex)
            {
                
                throw new Exception($"An error occurred while emptying cart {ShoppingCartId}: {ex.Message}", ex);
            }
        }

        public List<Product> GetProductsWithQuantity(int ShoppingCartId)
        {
            try
            {
                return carts.GetCartProductsWithQuantities(ShoppingCartId);
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler($"SQL error occurred while getting products with quantities from cart {ShoppingCartId}.", sqlEx);
            }
            catch (Exception ex)
            {
               
                throw new Exception($"An error occurred while getting products with quantities from cart {ShoppingCartId}.", ex);
            }
        }

        public List<Workshop> GetWorkshopsWithQuantity(int ShoppingCartId)
        {
            try
            {
                return carts.GetCartWorkshopsWithQuantities(ShoppingCartId);
            }
            catch (SqlException sqlEx)
            {
                // SQL Server specific exception handling
                throw new DatabaseExceptionHandler($"SQL error occurred while getting workshops with quantities from cart {ShoppingCartId}.", sqlEx);
            }
            catch (Exception ex)
            {
                
                throw new Exception($"An error occurred while getting workshops with quantities from cart {ShoppingCartId}.", ex);
            }
        }

    }
    
}
