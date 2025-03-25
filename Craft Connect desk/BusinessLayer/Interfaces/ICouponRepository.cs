using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICouponRepository
    {
        
        public List<Coupon> GetAllTheCoupons();
        public int GetDistinctBusinessCount(int cartId);
        public decimal GetTotalPriceOfMostCommonItemType(int cartID);
        public int GetHighestCountOfItemType(int cartId);
        //public Coupon GetCouponByDiscountType(DiscountType discountType);
        public decimal GetDiscountPercentage(int couponId);
        public bool AddCoupon(Coupon coupon);

        public Coupon GetCouponById(int id);
        public bool UpdateCoupon(Coupon coupon);
    }
}
