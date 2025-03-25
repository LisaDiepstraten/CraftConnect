using BusinessLayer.Interfaces;
using BusinessLayer.Models.DiscountSystem;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Models
{
    public static class DiscountFactory 
    {
        public static IDiscount GetDiscountStrategy(DiscountType discountType)
        {
            switch (discountType)
            {
                case DiscountType.NoDiscount:
                    return new NoDiscount();
                case DiscountType.SupportingMultipleBussDiscount:
                    return new SupportingMultipleBussDiscount();
                case DiscountType.TypeOfItemDiscount:
                    return new TypeOfItemDiscount();
                case DiscountType.CustomDiscount:
                    return new CustomDiscount();
               
                default:
                    throw new ArgumentException($"Unknown discount type: {discountType}");
            }
        }
 
    }
}
