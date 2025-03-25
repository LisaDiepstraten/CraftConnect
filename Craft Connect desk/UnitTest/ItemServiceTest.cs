using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.MockDataRepo;

namespace UnitTest
{
    [TestClass]
    public class ItemServiceTest
    {
        [TestMethod]
        public void AddWorkshop()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Workshop workshop = new Workshop(1, "candles making", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            bool result  = itemService.AddWorkshop(workshop);
            Assert.IsTrue(result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddWorkshopFail()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
       
            bool result = itemService.AddWorkshop(null);
           
        }

        [TestMethod]
        public void AddProduct()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Product product = new Product(1, "Candle", "Nice candle", "image.jpg", 10, 1, TypeOfItem.ScentedProducts, 40);
            bool result = itemService.AddProduct(product);
            Assert.IsTrue(result);
        }

        [ExpectedException(typeof(ArgumentException))] 
        [TestMethod]
        public void AddProductFail()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
              bool result = itemService.AddProduct(null);
           
        }

        [TestMethod]
        public void RemoveWorkshop()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Workshop workshop = new Workshop(1, "candles making", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);

            itemService.AddWorkshop(workshop);
            bool result = itemService.RemoveWorkshop((int)workshop.WorkshopId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveWorkshopFail()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            
            bool result = itemService.RemoveWorkshop(1);
            Assert.IsFalse(result);
        }

        
        [TestMethod]
        public void RemoveProduct()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Product product = new Product(1, "Candle", "Nice candle", "image.jpg", 10, 1, TypeOfItem.ScentedProducts, 40);

            itemService.AddProduct(product);
            bool result = itemService.RemoveProduct((int)product.ProductID);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveProductFail()
        {
            IItemService itemService = new ItemService(new MockItemRepo());

            bool result = itemService.RemoveProduct(1);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void GetWorkshops()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Workshop workshop1 = new Workshop(1, "candles making", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop2 = new Workshop(2, "Painting by color", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop3 = new Workshop(3, "Pottery", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            itemService.AddWorkshop(workshop1);
            itemService.AddWorkshop(workshop2);
            itemService.AddWorkshop(workshop3);

            List<Workshop> results = itemService.GetWorkshop(workshop1.BusinessId);

            // Compare the IDs of workshops in both lists
            Assert.AreEqual(workshop1.WorkshopId, results[0].WorkshopId);
            Assert.AreEqual(workshop2.WorkshopId, results[1].WorkshopId);
            Assert.AreEqual(workshop3.WorkshopId, results[2].WorkshopId);

        }
        // Your test method
        [TestMethod]
        public void GetProducts()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Product product1 = new Product(1, "Scented Candle", "Lovely scented candle","image.jpg", 10.99m, 2, TypeOfItem.ScentedProducts, 20);
            Product product2 = new Product(2, "Handcrafted Soap", "Luxurious handcrafted soap", "image2.jpg",7.99m, 2, TypeOfItem.ScentedProducts, 22);
            Product product3 = new Product(3, "Essential Oil", "High-quality essential oil", "image3.jpg",15.99m, 2, TypeOfItem.ScentedProducts, 21);
            itemService.AddProduct(product1);
            itemService.AddProduct(product2);
            itemService.AddProduct(product3);

            List<Product> results = itemService.GetProducts(product1.BusinessId);

            // Compare the IDs of products in both lists
            Assert.AreEqual(product1.ProductID, results[0].ProductID);
            Assert.AreEqual(product2.ProductID, results[1].ProductID);
            Assert.AreEqual(product3.ProductID, results[2].ProductID);
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Product product1 = new Product(1, "Scented Candle", "Lovely scented candle", "image.jpg", 10.99m, 2, TypeOfItem.ScentedProducts, 20);
            Product product2 = new Product(2, "Handcrafted Soap", "Luxurious handcrafted soap", "image2.jpg", 7.99m, 3, TypeOfItem.ScentedProducts, 22);
            Product product3 = new Product(3, "Essential Oil", "High-quality essential oil", "image3.jpg", 15.99m, 1, TypeOfItem.ScentedProducts, 21);
            itemService.AddProduct(product1);
            itemService.AddProduct(product2);
            itemService.AddProduct(product3);
            List<Product> results = itemService.GetAllProducts();
            Assert.AreEqual(product1.ProductID, results[0].ProductID);
            Assert.AreEqual(product2.ProductID, results[1].ProductID);
            Assert.AreEqual(product3.ProductID, results[2].ProductID);
        }

        [TestMethod]
        public void GetAllWorkshopsTest()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Workshop workshop1 = new Workshop(1, "candles making", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop2 = new Workshop(2, "Painting by color", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 2, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop3 = new Workshop(3, "Pottery", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 3, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            itemService.AddWorkshop(workshop1);
            itemService.AddWorkshop(workshop2);
            itemService.AddWorkshop(workshop3);
            List<Workshop> results = itemService.GetAllWorkshops();
            Assert.AreEqual(workshop1.WorkshopId, results[0].WorkshopId);
            Assert.AreEqual(workshop2.WorkshopId, results[1].WorkshopId);
            Assert.AreEqual(workshop3.WorkshopId, results[2].WorkshopId);
        }

        [TestMethod]
        public void GetProductById()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Product product1 = new Product(1, "Scented Candle", "Lovely scented candle", "image.jpg", 10.99m, 2, TypeOfItem.ScentedProducts, 20);
            Product product2 = new Product(2, "Handcrafted Soap", "Luxurious handcrafted soap", "image2.jpg", 7.99m, 3, TypeOfItem.ScentedProducts, 22);
            Product product3 = new Product(3, "Essential Oil", "High-quality essential oil", "image3.jpg", 15.99m, 1, TypeOfItem.ScentedProducts, 21);

            itemService.AddProduct(product1);
            itemService.AddProduct(product2);
            itemService.AddProduct(product3);

            Product result = itemService.GetProductById((int)product2.ProductID);
            Assert.AreEqual(result, product2);
        }

        [TestMethod]
        public void GetProductByIdFail()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Product product1 = new Product(1, "Scented Candle", "Lovely scented candle", "image.jpg", 10.99m, 2, TypeOfItem.ScentedProducts, 20);
            Product product2 = new Product(2, "Handcrafted Soap", "Luxurious handcrafted soap", "image2.jpg", 7.99m, 3, TypeOfItem.ScentedProducts, 22);
            Product product3 = new Product(3, "Essential Oil", "High-quality essential oil", "image3.jpg", 15.99m, 1, TypeOfItem.ScentedProducts, 21);

            itemService.AddProduct(product1);
            itemService.AddProduct(product2);
           

            Product result = itemService.GetProductById((int)product3.ProductID);
            Assert.AreNotEqual(result, product3);
        }

        [TestMethod]
        public void GetWorkshopById()
        {
            IItemService itemService = new ItemService(new MockItemRepo());
            Workshop workshop1 = new Workshop(1, "candles making", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 1, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop2 = new Workshop(2, "Painting by color", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 2, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            Workshop workshop3 = new Workshop(3, "Pottery", "beautiful", "image.jpg", "Boxtel", 12, 25, "Weekends", 3, TypeOfItem.ScentedProducts, DurationType.Min30To60);
            itemService.AddWorkshop(workshop1);
            itemService.AddWorkshop(workshop2);
            itemService.AddWorkshop(workshop3);
            Workshop result = itemService.GetWorkshopById((int)workshop2.WorkshopId);
            Assert.AreEqual(result, workshop2);
        }
    }
}
