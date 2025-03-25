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
    public class CouponServiceTest
    {
        [TestMethod]
        public void GetAllCouponsInTimeTest()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            List<Coupon> coupon = couponService.GetAllCouponsInTime();
            Assert.AreEqual(4, coupon.Count);
        }

        [TestMethod]
        public void GetAllCouponsInTimeTestFail()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            List<Coupon> coupon = couponService.GetAllCouponsInTime();
            Assert.AreNotEqual(6, coupon.Count);
        }

        [TestMethod]
        public void GetAllCoupons()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            List<Coupon> coupon = couponService.GetAllCoupons();
            Assert.AreEqual(6, coupon.Count);
        }

        [TestMethod]
        public void GetAmountSupportedBusinessesTest()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            int result = couponService.GetAmountSupportedBuss(1);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void GetTotalPriceAmountTypeTest()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            decimal result = couponService.GetTotalPriceAmountType(1);
            Assert.AreEqual(29.97m, result);
        }

        [TestMethod]
        public void GetHighestCountTypeTest()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            int result = couponService.GetHighestCountType(1);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetDiscountPercentageTest()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            decimal result = couponService.GetDiscountPercentage(3);
            Assert.AreEqual(0.25m, result);
        }

        [ExpectedException(typeof(CouponServiceException))] 
        [TestMethod]
        public void GetDiscountPercentageTestFail()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            decimal result = couponService.GetDiscountPercentage(0);
            
        }

        [TestMethod]
        public void GetCouponByIdTest()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            Coupon coupon2 = new Coupon(2, DiscountType.TypeOfItemDiscount, "Winter Sale", "Discount on specific types of items", new DateTime(2024, 11, 30), 0.20m);

            Coupon result = couponService.GetCouponById(2);
            Assert.AreEqual(coupon2.Id, result.Id);
            Assert.AreEqual(coupon2.DiscountType, result.DiscountType);
            Assert.AreEqual(coupon2.Name, result.Name);
            Assert.AreEqual(coupon2.Description, result.Description);
            Assert.AreEqual(coupon2.ExpirationDate, result.ExpirationDate);
            Assert.AreEqual(coupon2.Percentage, result.Percentage);
        }

        [TestMethod]
        public void AddCouponTest()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
            Coupon coupon7 = new Coupon(7, DiscountType.SupportingMultipleBussDiscount, "Summer Sale", "Discount on multiple business support", new DateTime(2024, 12, 31), 0.15m);

            bool result = couponService.AddCoupon(coupon7);
            Assert.IsTrue(result);
        }

        [ExpectedException(typeof(CouponServiceException))]
        [TestMethod]
        public void AddCouponTestFail()
        {
            CouponService couponService = new CouponService(new MockCouponRepo());
        
            bool result = couponService.AddCoupon(null);
            
        }
    }
}
