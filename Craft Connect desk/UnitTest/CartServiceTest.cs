using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.MockDataRepo;

namespace UnitTest
{
    [TestClass]
    public class CartServiceTest
    {
 

        [TestMethod]
        public void InsertWorkshopToCartTest()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());
            CartService cartService = new CartService(new MockCartRepo());

            User user = new User(1, "JoelH", "Joel", "Hansen", "023966284", "Tilburg", "Joel@gmail.com", "pass123!", 8, 1);
            User user2 = new User(2, "ZoeJ", "Zoe", "Johnsen", "023966674", "Eindhoven", "ZoeJ@gmail.com", "pass123!", 10, 2);

            accountService.AddUser(user);
            accountService.AddUser(user2);

            Workshop workshop1 = new Workshop(1, "candles making", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop2 = new Workshop(2, "Painting by color", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop3 = new Workshop(3, "Pottery", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);

            bool result = cartService.InsertWorkshopToCart((int)user2.ShoppingcartId, (int)workshop3.WorkshopId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InsertProductToCartTest()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());
            CartService cartService = new CartService(new MockCartRepo());

            User user = new User(1, "JoelH", "Joel", "Hansen", "023966284", "Tilburg", "Joel@gmail.com", "pass123!", 8, 1);
            User user2 = new User(2, "ZoeJ", "Zoe", "Johnsen", "023966674", "Eindhoven", "ZoeJ@gmail.com", "pass123!", 10, 2);

            accountService.AddUser(user);
            accountService.AddUser(user2);

            Workshop workshop1 = new Workshop(1, "candles making", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop2 = new Workshop(2, "Painting by color", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop3 = new Workshop(3, "Pottery", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);

            bool result = cartService.InsertWorkshopToCart((int)user2.ShoppingcartId, (int)workshop3.WorkshopId);
            Assert.IsTrue(result);
        }


    }
}
