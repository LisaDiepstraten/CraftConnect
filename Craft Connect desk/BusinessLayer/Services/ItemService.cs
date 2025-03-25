using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ItemService : IItemService
    {

        private IItemRepository itemRepository;

        public ItemService(IItemRepository itemrepository)
        {
            this.itemRepository = itemrepository;

        }


        public bool AddWorkshop(Workshop workshop)
        {
            try
            {
                if (workshop != null && workshop.AmountOfPlaces >= 0)
                {
                    return itemRepository.CreateItem((Workshop)workshop);

                }
                else
                {
                    throw new ArgumentException("Invalid workshop data.");
                }
            }
            catch (ArgumentException ex)
            {
                // Specific handling for argument-related exceptions in the Logic Layer
                throw new ArgumentException("Invalid workshop data in the Logic Layer.", ex);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while adding the workshop in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while adding the workshop in the Logic Layer.", ex);
            }
        }

        public bool AddProduct(Product product)
        {
            try
            {
                if (product != null && product.AmountInStock > 0)
                {
                    return itemRepository.CreateItem(product);

                }
                else
                {
                    throw new ArgumentException("Invalid product data.");
                }
            }
            catch (ArgumentException ex)
            {
                // Specific handling for argument-related exceptions in the Logic Layer
                throw new ArgumentException("Invalid product data in the Logic Layer.", ex);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while adding the product in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while adding the product in the Logic Layer.", ex);
            }
        }

        public List<Workshop> GetWorkshop(int businessId)
        {
            try
            {
                if (businessId > 0)
                {
                    return itemRepository.GetWorkshopsByBusinessId(businessId);
                }

                else
                {
                    throw new ArgumentException("Business ID must be greater than 0.");
                }
            }
            catch (ArgumentException ex)
            {
                // Specific handling for argument-related exceptions in the Logic Layer
                throw new ArgumentException("Invalid business ID in the Logic Layer.", ex);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while retrieving workshops by business ID in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while retrieving workshops by business ID in the Logic Layer.", ex);
            }
        }

        public bool RemoveWorkshop(int workshopid)
        {
            try
            {
                if (workshopid > 0)
                {
                    bool result = itemRepository.RemoveWorkshop(workshopid);
                    return result;
                }
                else
                {
                    throw new ArgumentException("Invalid workshop ID provided.");
                }
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while removing the workshop in the Logic Layer.", dbEx);
            }
            catch (ArgumentException argEx)
            {
                // Handling specific argument-related exceptions
                throw new LogicLayerException("Invalid workshop ID provided for removal in the Logic Layer.", argEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while removing the workshop in the Logic Layer.", ex);
            }
        }

        public List<Product> GetProducts(int businessId)
        {
            try
            {
                if (businessId > 0)
                {
                    return itemRepository.GetProductsByBusinessId(businessId);
                }
                else
                {
                    throw new ArgumentException("Invalid business ID provided.");
                }
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while retrieving products in the Logic Layer.", dbEx);
            }
            catch (ArgumentException argEx)
            {
                // Handling specific argument-related exceptions
                throw new LogicLayerException("Invalid business ID provided for retrieving products in the Logic Layer.", argEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while retrieving products in the Logic Layer.", ex);
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                List<Product> products = itemRepository.GetAllProducts();
                return products;
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while retrieving all products in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while retrieving all products in the Logic Layer.", ex);
            }
        }

        public bool RemoveProduct(int productId)
        {
            try
            {
                if (productId > 0)
                {
                    return itemRepository.RemoveProduct(productId);
                }
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while removing the product in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while removing the product in the Logic Layer.", ex);
            }
            return false;
        }

        public void UpdateWorkshop(Workshop workshop)
        {
            try
            {
                itemRepository.UpdateItem(workshop);
            }

            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while updating the workshop in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while updating the workshop in the Logic Layer.", ex);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                itemRepository.UpdateItem(product);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while updating the product in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while updating the product in the Logic Layer.", ex);
            }
        }

        public Workshop GetWorkshopById(int id)
        {
            try
            {
                return itemRepository.GetWorkshopById(id);
            }
            catch (WorkshopNotFoundException ex)
            {
                // Rethrow WorkshopNotFoundException directly
                throw;
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while retrieving the workshop by ID in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while retrieving the workshop by ID in the Logic Layer.", ex);
            }

        }

        public Product GetProductById(int id)
        {
            try
            {
                return itemRepository.GetProductByIdP(id);
            }
            catch (ProductNotFoundException ex)
            {
                // Rethrow ProductNotFoundException directly
                throw;
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while retrieving the product by ID in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while retrieving the product by ID in the Logic Layer.", ex);
            }
        }
        

        public List<Workshop> GetAllWorkshops()
        {
            try
            {
                return itemRepository.GetAllWorkshops();
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Specific handling for database-related exceptions thrown by the DAL
                throw new LogicLayerException("A database-related error occurred while retrieving all workshops in the Logic Layer.", dbEx);
            }
            catch (Exception ex)
            {
                // General handling for other exceptions in the Logic Layer
                throw new LogicLayerException("An error occurred while retrieving all workshops in the Logic Layer.", ex);
            }
        }

        public void DecreaseAmount(int cartId)
        {
            try
            {
                itemRepository.DecreaseStockForCartP(cartId);
                itemRepository.DecreaseStockForCartW(cartId);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while decreasing the stock for the cart.", dbEx);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while decreasing the stock for the cart.", ex);
            }
            

        }

        public List<Product> GetProductsByPagination(int pagenumber)
        {
            try
            {
                return itemRepository.GetProductsByPagination(pagenumber);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                
                throw; // Rethrow the exception for higher layers to handle
            }
            catch (Exception ex)
            {
                // Handle or log other unexpected exceptions
                
                throw new Exception("An unexpected error occurred in business logic layer.", ex);
            }
        }

    }
}
