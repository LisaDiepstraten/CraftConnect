using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Coupon
    {
        public int? Id { get; private set; }
        public DiscountType DiscountType{ get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
      
        public DateTime ExpirationDate { get; private set; }

        public decimal Percentage { get; private set; }

        public Coupon(int? id, DiscountType discountType, string name, string description, DateTime expirationdate, decimal percentage )
        {
            this.Id = id;
            this.DiscountType = discountType;
            this.Name = name;
            this.Description = description;
           
            this.ExpirationDate = expirationdate;
            this.Percentage = percentage;
        }
    }

    
}
