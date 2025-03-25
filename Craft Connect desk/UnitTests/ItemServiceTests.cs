//using BusinessLayer.Interfaces;
//using BusinessLayer.Models;
//using BusinessLayer.Services;
//using DataAccessLibrary.MockData;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace UnitTests
//{
//    public class ItemServiceTests 
//    {
//        //IItemRepository repoitem = new MockItemRepository();
//        IItemService itemservice = new ItemService(new MockItemRepository());
//        Item workshop = new Workshop(40, "DiamondPainting", "Making a diamond painting", "test.jpg", "Sofia", 20, 45, "Monday, Tuesday", 3, TypeOfItem.Painting, DurationType.Min30To60);
//        Item workshop2 = new Workshop(40, "DiamondPainting", "Making a beautiful diamond painting", "test.jpg", "Sofia", 20, 45, "Monday, Tuesday", 3, TypeOfItem.Painting, DurationType.Min30To60);

//        [Fact]
//        [TestMethod]
//        public void AddWorkshopTest()
//        {
//            itemservice.AddWorkshop((Workshop)workshop);
//        }

//        [Fact]
//        [TestMethod]
//        public void RemoveWorkshopTest()
//        {
//            itemservice.RemoveWorkshop((int)workshop.Id);
//        }

//        [Fact]
//        [TestMethod]
//        public void GetWorkshopTest()
//        {
//            itemservice.GetWorkshop(workshop.BusinessId);
//        }

//      //arrange act assert



//    }
//}
