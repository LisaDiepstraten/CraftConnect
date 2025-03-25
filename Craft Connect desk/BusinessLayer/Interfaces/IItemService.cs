using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IItemService
    {
        public bool AddWorkshop(Workshop workshop);
        public List<Workshop> GetWorkshop(int businessId);
        public bool RemoveWorkshop(int workshopid);
        public bool AddProduct(Product Product);
        public List<Product> GetProducts(int businessId);
        public bool RemoveProduct(int productid);
        public void UpdateWorkshop(Workshop workshop);
        public void UpdateProduct(Product product);
        public Workshop GetWorkshopById(int id);
        public Product GetProductById(int id);

        public List<Product> GetAllProducts();

        public List<Workshop> GetAllWorkshops();
        public void DecreaseAmount(int cartId);
        public List<Product> GetProductsByPagination(int pagenumber);

    }
}
