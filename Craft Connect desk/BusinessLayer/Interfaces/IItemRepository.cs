using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IItemRepository
    {
        public bool CreateItem(Item item);
        public List<Workshop> GetWorkshopsByBusinessId(int businessId);

        public bool RemoveWorkshop(int workshopId);
        public List<Product> GetProductsByBusinessId(int businessId);
        public bool RemoveProduct(int productId);
        public bool UpdateItem(Item item);
        public Workshop GetWorkshopById(int WorkshopId);
        public Product GetProductByIdP(int ProductId);

       
        public List<Product> GetAllProducts();

        public List<Workshop> GetAllWorkshops();

        public void DecreaseStockForCartP(int cartId);
        public void DecreaseStockForCartW(int cartId);
        public List<Product> GetProductsByPagination(int pageNumber);
    }
}
