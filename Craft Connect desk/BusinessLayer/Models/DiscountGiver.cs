using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class DiscountGiver
    {

        private readonly IDiscount discount;

        public DiscountGiver(DiscountType discountType)
        {

            discount = DiscountFactory.GetDiscountStrategy(discountType);
        }

        public decimal ApplyDiscount(decimal cartAmount, int amountBusinessSupp, decimal percentage, decimal TotalPriceAmountType, int CountType)
        {
            if (discount != null)
            {
                return discount.CalculateDiscount(cartAmount, amountBusinessSupp, percentage, TotalPriceAmountType, CountType);
            }

            throw new InvalidOperationException("No discount strategy has been set.");
        }
    }
}

