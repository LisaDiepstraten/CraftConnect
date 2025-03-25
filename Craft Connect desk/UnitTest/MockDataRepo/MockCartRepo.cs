using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MockDataRepo
{
    public class MockCartRepo : ICartRepository
    {
        public void AddProductToCart(int ShoppingcartId, int productid)
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, List<int>> cartItems = new Dictionary<int, List<int>>();

        public void AddWorkshopToCart(int shoppingcartId, int workshopId)
        {
            if (!cartItems.ContainsKey(shoppingcartId))
            {
                cartItems[shoppingcartId] = new List<int>();
            }
            cartItems[shoppingcartId].Add(workshopId);
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Workshop> GetAllWorkshops()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetCartProducts(List<int> productids)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetCartProductsWithQuantities(int cartId)
        {
            throw new NotImplementedException();
        }

        public List<Workshop> GetCartWorkshops(List<int> workshopsids)
        {
            throw new NotImplementedException();
        }

        public List<Workshop> GetCartWorkshopsWithQuantities(int cartId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetProductsInCart(int ShoppingcartId)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalCartAmount(int cartId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetWorkshopsInCart(int ShoppingcartId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCartItemsByCartId(int cartId)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductFromCart(int ShoppingCartId, int ProductId)
        {
            throw new NotImplementedException();
        }

        public void RemoveWorkshopFromCart(int ShoppingCartId, int WorkshopId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPoints(int userId, int additionalPoints)
        {
            throw new NotImplementedException();
        }
    }
}
