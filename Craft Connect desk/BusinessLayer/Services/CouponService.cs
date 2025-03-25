using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CouponService
    {

        private ICouponRepository couponRepository;

        public CouponService(ICouponRepository coupon)
        {
            this.couponRepository = coupon ?? throw new ArgumentNullException(nameof(coupon));
        }

        public List<Coupon> GetAllCouponsInTime()
        {
            List<Coupon> coupons = new List<Coupon>();

            try
            {
                foreach (Coupon coup in couponRepository.GetAllTheCoupons())
                {
                    if (coup.ExpirationDate >= DateTime.Today)
                    {
                        
                        coupons.Add(coup);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CouponServiceException("Error fetching coupons in time.", ex);
            }

            return coupons;
        }

        public List<Coupon> GetAllCoupons()
        {
            try
            {
                var allCoupons = couponRepository.GetAllTheCoupons();
                if (allCoupons != null)
                {
                    return allCoupons;
                }
                else
                {
                    throw new CouponNotFoundException("No coupons found.");
                }
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                throw new CouponServiceException("Error fetching all coupons from the database.", dbEx);
            }
            catch (CouponNotFoundException)
            {
                throw; // Re-throw specific exception
            }
            catch (Exception ex)
            {
                throw new CouponServiceException("An unexpected error occurred while fetching all coupons.", ex);
            }
        }

        public int GetAmountSupportedBuss(int cartId)
        {
            try
            {
                return couponRepository.GetDistinctBusinessCount(cartId);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Handle DAL-specific exceptions
                throw new CouponServiceException("Database error occurred while getting amount supported by business.", dbEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new CouponServiceException("An unexpected error occurred while getting amount supported by business.", ex);
            }
        }

        public decimal GetTotalPriceAmountType(int cartId)
        {
            try
            {
                return couponRepository.GetTotalPriceOfMostCommonItemType(cartId);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Handle DAL-specific exceptions
                throw new CouponServiceException("Database error occurred while getting the total price of the most common item type.", dbEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new CouponServiceException("An unexpected error occurred while getting the total price of the most common item type.", ex);
            }
        }

        public int GetHighestCountType(int cartId)
        {
            try
            {
                return couponRepository.GetHighestCountOfItemType(cartId);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                // Handle DAL-specific exceptions
                throw new CouponServiceException("Database error occurred while getting the highest count of item types.", dbEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new CouponServiceException("An unexpected error occurred while getting the highest count of item types.", ex);
            }
        }

        public decimal GetDiscountPercentage(int discountid)
        {
            try
            {
                return couponRepository.GetDiscountPercentage(discountid);
            }
            catch (CouponNotFoundException ex)
            {
                throw new CouponServiceException($"Error: percentage not found for ID '{discountid}'.", ex);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                throw new CouponServiceException($"Database error occurred while fetching the percentage of coupon with ID '{discountid}'.", dbEx);
            }
            catch (Exception ex)
            {
                throw new CouponServiceException($"An unexpected error occurred while fetching the percentage of coupon with ID '{discountid}'.", ex);
            }
        }

        public Coupon GetCouponById(int id)
        {
            try
            {
                var coupon = couponRepository.GetCouponById(id);
                if (coupon == null)
                {
                    throw new CouponNotFoundException($"Coupon with ID '{id}' not found.");
                }
                return coupon;
            }
            catch (CouponNotFoundException)
            {
                throw; // Re-throw the existing CouponNotFoundException
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                throw new CouponServiceException("Database error occurred while getting the coupon by ID.", dbEx);
            }
            catch (Exception ex)
            {
                throw new CouponServiceException($"An unexpected error occurred while getting the coupon by ID '{id}'.", ex);
            }
        }

        public bool AddCoupon(Coupon coupon)
        {
            try
            {
                return couponRepository.AddCoupon(coupon);


            }
            catch (DatabaseExceptionHandler dbEx)
            {
                throw new CouponServiceException("Database error occurred while adding a coupon.", dbEx);
            }
            catch (Exception ex)
            {
                throw new CouponServiceException("Error adding coupon.", ex);
            }
        }

        public void UpdateCoupon(Coupon coupon)
        {
            try
            {
                couponRepository.UpdateCoupon(coupon);
            }
            catch (DatabaseExceptionHandler dbEx)
            {
                throw new CouponServiceException("Database error occurred while updating the coupon.", dbEx);
            }
            catch (Exception ex)
            {
                throw new CouponServiceException("An unexpected error occurred while updating the coupon.", ex);
            }
        }
    }
}
