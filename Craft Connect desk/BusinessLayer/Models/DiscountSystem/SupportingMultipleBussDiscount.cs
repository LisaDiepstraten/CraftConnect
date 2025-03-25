using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.DiscountSystem
{
    public class SupportingMultipleBussDiscount : IDiscount
    {
        
        public decimal CalculateDiscount(decimal shoppingAmount,int amountofbusssupported, decimal percentage, decimal TotalPriceAmountType, int CountType )// ,decimal getal no hardcoded percentages
            {
            decimal minDiscount = shoppingAmount * percentage;  //0,15
            decimal initialDiscount = minDiscount + amountofbusssupported;

         

            if (initialDiscount < (minDiscount))
            {
                initialDiscount += 1;
                
            }
            return Math.Round(initialDiscount,2);
            
        }

       


    }
}
