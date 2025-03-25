using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.MockData
{
    public class MockItemRepository 
    {
        private List<Item> item = new List<Item>();



        public bool CreateItem(Item item)
        {
            if (item != null)
            {
                this.item.Add(item);
                return true;
            }
            return false;
        }

      

        public void DecreaseStockForCartP(int cartId)
        {
            throw new NotImplementedException();
        }

        public void DecreaseStockForCartW(int cartId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

     

        public List<Workshop> GetAllWorkshops()
        {
            throw new NotImplementedException();
        }

    

 

        public Product GetProductByIdP(int ProductId)
        {
            foreach(Product product in this.item)
            {
                if (product.ProductID == ProductId)
                {
                    return product;
                }
                break;
            }
            return null;
        }

        public List<Product> GetProductsByBusinessId(int businessId)
        {
            List<Product> products = new List<Product>();
            foreach(Product product in item)
            {
                if(product.BusinessId == businessId)
                {
                    products.Add(product);
                }
            }
            return products;
        }


        public Workshop GetWorkshopById(int WorkshopId)
        {
            foreach(Workshop workshop in this.item)
            {
                if(workshop.WorkshopId == WorkshopId)
                {
                    return workshop;
                }
            }
            return null;
        }

        public List<Workshop> GetWorkshopsByBusinessId(int businessId)
        {
            List<Workshop> workshops = new List<Workshop>();
            foreach (Workshop workshop in item)
            {
                if (workshop.BusinessId == businessId)
                {
                    workshops.Add(workshop);
                }
            }
            return workshops;
        }

   
        public bool RemoveProduct(int productId)
        {
            foreach(Product product in item)
            {
                if (product.ProductID == productId)
                {
                    item.Remove(product);
                    return true;
                    
                }
            }
            return false;
        }

      

        public bool RemoveWorkshop(int workshopId)
        {
            foreach (Workshop workshop in item)
            {
                if (workshop.WorkshopId == workshopId)
                {
                    item.Remove(workshop);
                    return true;
                }
            }
            return false;
        }


        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

       
    }
}
