using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MockDataRepo
{
    public class MockCouponRepo : ICouponRepository
    {
        List<Coupon> coupons = new List<Coupon>();
        List<Product> products = new List<Product>();

        public MockCouponRepo()
        {
            Product product1 = new Product(1, "Scented Candle", "Lovely scented candle", "image.jpg", 10.99m, 2, TypeOfItem.ScentedProducts, 20);
            Product product2 = new Product(2, "Handcrafted Soap", "Luxurious handcrafted soap", "image2.jpg", 7.99m, 1, TypeOfItem.ScentedProducts, 22);
            Product product3 = new Product(3, "Essential Oil", "High-quality essential oil", "image3.jpg", 15.99m, 3, TypeOfItem.ScentedProducts, 21);
            Product product4 = new Product(4, "Scented Candle", "Lovely scented candle", "image.jpg", 10.99m, 2, TypeOfItem.ScentedProducts, 20);
            Product product5 = new Product(5, "Handcrafted Soap", "Luxurious handcrafted soap", "image2.jpg", 7.99m, 2, TypeOfItem.ScentedProducts, 22);
            Product product6 = new Product(6, "Essential Oil", "High-quality essential oil", "image3.jpg", 10.99m, 4, TypeOfItem.ScentedProducts, 21);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);


            Coupon coupon1 = new Coupon(1, DiscountType.SupportingMultipleBussDiscount, "Summer Sale", "Discount on multiple business support", new DateTime(2024, 12, 31), 0.15m);
            Coupon coupon2 = new Coupon(2, DiscountType.TypeOfItemDiscount, "Winter Sale", "Discount on specific types of items", new DateTime(2024, 11, 30), 0.20m);
            Coupon coupon3 = new Coupon(3, DiscountType.CustomDiscount, "Year-end Clearance", "Customized discount for loyal customers", new DateTime(2023, 12, 31), 0.25m);
            Coupon coupon4 = new Coupon(4, DiscountType.CustomDiscount, "New Year Welcome Sale", "Welcome discount for new customers", new DateTime(2024, 12, 31), 0.10m);
            Coupon coupon5 = new Coupon(5, DiscountType.CustomDiscount, "Loyalty Appreciation Sale", "Discount for loyal customers", new DateTime(2024, 12, 31), 0.15m);
            Coupon coupon6 = new Coupon(6, DiscountType.NoDiscount, "Regular Price", "No discount applied", new DateTime(2024, 6, 12), 0m);
            coupons.Add(coupon1);
            coupons.Add(coupon2);
            coupons.Add(coupon3);
            coupons.Add(coupon4);
            coupons.Add(coupon5);
            coupons.Add(coupon6);
        }
        public bool AddCoupon(Coupon coupon)
        {
            if (coupon != null)
            {
                coupons.Add(coupon);
                return true;
            }
            else { throw new CouponNotFoundException($"Coupon '{coupon}' not found."); }

        }

        public List<Coupon> GetAllTheCoupons()
        {
            return coupons;
        }


        public Coupon GetCouponById(int id)
        {
            Coupon rightcoupon = null;
            foreach (Coupon coupon in coupons)
            {
                if (coupon.Id == id)
                {
                    rightcoupon = coupon;
                    break;
                }
            }
            return rightcoupon;
        }

        public decimal GetDiscountPercentage(int couponId)
        {
            if (couponId > 0)
            {
                foreach (Coupon coupon in coupons)
                {
                    if (coupon.Id == couponId)
                    {
                        return coupon.Percentage;
                    }
                }
                return 0;
            }
            else
            {
                throw new CouponNotFoundException($"Coupon with ID '{couponId}' not found.");
            }
        }

        public int GetDistinctBusinessCount(int cartId)
        {
            if (cartId <= 0)
            {
                throw new ArgumentException("Invalid cart ID");
            }

            List<Product> producten = products; // Get products for the given cart ID

            if (products == null || products.Count == 0)
            {
                return 0; // No products in the cart
            }

            HashSet<int> distinctBusinessIds = new HashSet<int>();

            foreach (Product product in products)
            {
                distinctBusinessIds.Add(product.BusinessId);
            }

            return distinctBusinessIds.Count;
        }


        public int GetHighestCountOfItemType(int cartId)
        {
            if (cartId != null)
            {
                return 3;
            }
            return 0;

        }




        public decimal GetTotalPriceOfMostCommonItemType(int cartID)
        {
            if (cartID != null)
            {
                return 29.97m;
            }
            return 0;
        }


        public bool UpdateCoupon(Coupon coupon)
        {
            foreach (Coupon singlecoupon in coupons)
            {
                if (singlecoupon.Id == coupon.Id)
                {
                    coupons.Remove(singlecoupon);
                    coupons.Add(coupon);
                    return true;
                }
            }
            return false;

        }
    }
}
