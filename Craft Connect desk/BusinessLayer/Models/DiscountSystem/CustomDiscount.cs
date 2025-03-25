using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.DiscountSystem
{
    public class CustomDiscount : IDiscount
    {
        public decimal CalculateDiscount(decimal shoppingamount, int amountsupportedbuss, decimal percentage, decimal TotalPriceAmountType, int CountType)
        {
            decimal discountamount = (shoppingamount * percentage);
            return Math.Round(discountamount, 2);
            
        }

      
    }
}
