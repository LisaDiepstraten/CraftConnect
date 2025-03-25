using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICartRepository
    {
        
        public void AddWorkshopToCart(int ShoppingcartId, int workshopid);
        public void AddProductToCart(int ShoppingcartId, int productid);
        public List<int> GetProductsInCart(int ShoppingcartId);
        public List<int> GetWorkshopsInCart(int ShoppingcartId);
        public void RemoveWorkshopFromCart(int ShoppingCartId, int WorkshopId);
        public void RemoveProductFromCart(int ShoppingCartId, int ProductId);
    
        public decimal GetTotalCartAmount(int cartId);
       
        public void UpdateUserPoints(int userId, int additionalPoints);

        public void RemoveCartItemsByCartId(int cartId);

        public List<Product> GetCartProductsWithQuantities(int cartId);
        public List<Workshop> GetCartWorkshopsWithQuantities(int cartId);
    }
}
