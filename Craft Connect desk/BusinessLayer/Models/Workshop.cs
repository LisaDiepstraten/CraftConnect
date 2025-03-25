using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
  
    public class Workshop : Item
    {
        public int? WorkshopId { get; private set; }
        public string WorkshopName { get; private set; }
        public string Image { get; private set; }
        public string Location { get; private set; }
        public decimal Price { get; private set; }
        public DurationType Duration { get; private set; }
        public int AmountOfPlaces { get; private set; }
        public string DaysAvailable { get; private set; }
        public int? ItemId { get; private set; }
        public int Quantity { get; private set; }



        public Workshop(int? Workshopid, string workshopName, string description, string image, string location, decimal price, int amountOfPlaces, string daysAvailable, int businessId, TypeOfItem typeOfItem, DurationType duration)
            : base(null, description, businessId, typeOfItem)
        {
            if (string.IsNullOrWhiteSpace(workshopName))
                throw new ArgumentException("Workshop name cannot be null or whitespace.", nameof(workshopName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location cannot be null or whitespace.", nameof(location));
            if (price <= 0)
                throw new ArgumentException("Price must be a positive value.", nameof(price));
            if (amountOfPlaces <= 0)
                throw new ArgumentException("Amount of places must be a positive integer.", nameof(amountOfPlaces));
            if (string.IsNullOrWhiteSpace(daysAvailable))
                throw new ArgumentException("Days available cannot be null or whitespace.", nameof(daysAvailable));

            this.WorkshopId = Workshopid;
            this.WorkshopName = workshopName;
            this.Image = image;
            this.Location = location;
            this.Price = price;
            this.AmountOfPlaces = amountOfPlaces;
            this.DaysAvailable = daysAvailable;
            this.Duration = duration;

        }
        public Workshop(int? Workshopid,int? id, string workshopName, string description, string image, string location, decimal price, int amountOfPlaces, string daysAvailable, int businessId, TypeOfItem typeOfItem, DurationType duration)
            : base(id, description, businessId, typeOfItem)
        {
            if (string.IsNullOrWhiteSpace(workshopName))
                throw new ArgumentException("Workshop name cannot be null or whitespace.", nameof(workshopName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location cannot be null or whitespace.", nameof(location));
            if (price <= 0)
                throw new ArgumentException("Price must be a positive value.", nameof(price));
            if (amountOfPlaces <= 0)
                throw new ArgumentException("Amount of places must be a positive integer.", nameof(amountOfPlaces));
            if (string.IsNullOrWhiteSpace(daysAvailable))
                throw new ArgumentException("Days available cannot be null or whitespace.", nameof(daysAvailable));

            this.WorkshopId = Workshopid;
            this.WorkshopName = workshopName;
            this.Image = image;
            this.Location = location;
            this.Price = price;
            this.AmountOfPlaces = amountOfPlaces;
            this.DaysAvailable = daysAvailable;
            this.Duration = duration;
            this.ItemId = id;
          
        }

        public Workshop(int workshopId, int itemId, string workshopName, string description, string image, string location, decimal price, int amountOfPlaces, string daysAvailable, int businessId, TypeOfItem itemType, DurationType duration, int quantity)
        : this(workshopId, itemId, workshopName, description, image, location, price, amountOfPlaces, daysAvailable, businessId, itemType, duration)
        {
            Quantity = quantity;
        }
    }
}
