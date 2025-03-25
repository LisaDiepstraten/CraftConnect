using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MockDataRepo
{
    public class MockItemRepo : IItemRepository
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
            List<Product> products = new List<Product>();
            foreach(var product in item)
            {
                if (product is Product)
                {
                    products.Add((Product)product);
                }
            }
            return products;
        }

        public List<Workshop> GetAllWorkshops()
        {
            List<Workshop> workshop = new List<Workshop>();
            foreach (var workshopItem in item)
            {
                if(workshopItem is Workshop)
                {
                    workshop.Add((Workshop)workshopItem);
                }
            }
            return workshop;
        }

        public Product GetProductByIdP(int ProductId)
        {
            List<Product> product = new List<Product>();
            Product foundproduct = null;
            foreach (var productitem in item)
            {
                if (productitem is Product)
                {
                   
                    product.Add((Product)productitem);
                }
            }
            foreach(Product oneproduct in product)
            {
                if(oneproduct.ProductID == ProductId)
                {
                   foundproduct = oneproduct;
                    break;
                }
            }
            return foundproduct;
        }

        public List<Product> GetProductsByBusinessId(int businessId)
        {
            List<Product> product = new List<Product>();
            foreach (var productitem in item)
            {
                if (productitem is Product && productitem.BusinessId == businessId)
                {
                    product.Add((Product)productitem);
                }
            }
            return product;
        }

        public List<Product> GetProductsByPagination(int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Workshop GetWorkshopById(int WorkshopId)
        {
            List<Workshop> workshop = new List<Workshop>();
            Workshop foundworkshop = null;
            foreach (var workshopitem in item)
            {
                if (workshopitem is Workshop)
                {

                    workshop.Add((Workshop)workshopitem);
                }
            }
            foreach (Workshop oneworkshop in workshop)
            {
                if (oneworkshop.WorkshopId == WorkshopId)
                {
                    foundworkshop = oneworkshop;
                    break;
                }
            }
            return foundworkshop;
        }

        public List<Workshop> GetWorkshopsByBusinessId(int businessId)
        {
            List<Workshop> workshop = new List<Workshop>();
            foreach (var workshopItem in item)
            {
                if (workshopItem is Workshop && workshopItem.BusinessId == businessId)
                {
                    workshop.Add((Workshop)workshopItem);
                }
            }
            return workshop;
        }

        public bool RemoveProduct(int productId)
        {
            if (productId > 0 && productId <= item.Count)
            {
                item.RemoveAt(productId - 1);
                return true;
            }
            return false;
        }

        public bool RemoveWorkshop(int workshopId)
        {
            // Check if workshopId is valid
            if (workshopId > 0 && workshopId <= item.Count)
            {
                
                item.RemoveAt(workshopId - 1);
                return true;
            }
            return false;
        }


        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
