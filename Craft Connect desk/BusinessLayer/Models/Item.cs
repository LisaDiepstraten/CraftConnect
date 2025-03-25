using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    
    public class Item
    {
        public int? Id { get; private set; }
        public int BusinessId { get; private set; }
        public string Description { get; private set; }
        public TypeOfItem TypeOfItem { get; private set; }

        public Item(int? id, string description, int businessId, TypeOfItem itemType)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or whitespace.", nameof(description));
            if (businessId <= 0)
                throw new ArgumentException("Business ID must be a positive integer.", nameof(businessId));

            Id = id;
            Description = description;
            BusinessId = businessId;
            TypeOfItem = itemType;
        }
    }
}
