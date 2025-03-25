using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IDiscount
    {
        public decimal CalculateDiscount(decimal CartAmount, int amountbusinesssupported, decimal percentage, decimal TotalPriceAmountType, int CountType);   
    }
}

