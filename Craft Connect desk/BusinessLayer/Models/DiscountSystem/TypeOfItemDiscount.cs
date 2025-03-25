using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.DiscountSystem
{
    public class TypeOfItemDiscount : IDiscount
    {

        public decimal CalculateDiscount(
            decimal cartAmount,
            int amountSupportedBuss,
            decimal percentage,
            decimal totalPriceAmountType,
            int countType)
        {
            decimal discount = totalPriceAmountType + countType;   
            decimal totalAmountDiscount = (discount/100) * cartAmount;    

            // Ensure the discount does not exceed the total cart amount
            if (totalAmountDiscount > cartAmount)
            {
                totalAmountDiscount = cartAmount;
            }

           
            decimal maxDiscount = cartAmount * 0.35m;  

            
            if (totalAmountDiscount > maxDiscount)
            {
                totalAmountDiscount = maxDiscount;
            }

            
            decimal baseDiscount = totalAmountDiscount * percentage;    
            decimal baseDis = Math.Round(baseDiscount, 2);
            return baseDis;
        }
    }



}

