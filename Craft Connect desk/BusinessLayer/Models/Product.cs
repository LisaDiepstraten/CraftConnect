using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Models
{
 
    public class Product : Item
    {
        public int? ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public int AmountInStock { get; private set; }
        public int Quantity {  get; private set; }


        public Product(int? productId, string productName, string description, string image, decimal price, int businessId, TypeOfItem typeOfItem, int amountInStock) : base(null, description, businessId, typeOfItem)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
            if (price <= 0)
                throw new ArgumentException("Price must be a positive value.", nameof(price));
            if (amountInStock < 0)
                throw new ArgumentException("Amount in stock cannot be negative.", nameof(amountInStock));
            this.ProductID = productId;
            ProductName = productName;
            Image = image;
            Price = price;
            AmountInStock = amountInStock;
        }

        public Product(int? Productid, int? itemId, string productName, string description, string image, decimal price, int businessId, TypeOfItem typeOfItem, int amountInStock)
             : base(itemId, description, businessId, typeOfItem)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
            if (price <= 0)
                throw new ArgumentException("Price must be a positive value.", nameof(price));
            if (amountInStock < 0)
                throw new ArgumentException("Amount in stock cannot be negative.", nameof(amountInStock));
            ProductID = Productid;
            ProductName = productName;
            Image = image;
            Price = price;
            AmountInStock = amountInStock;
           
        }

        public Product(int productId, int itemId, string productName, string description, string image, decimal price, int businessId, TypeOfItem itemType, int amountInStock, int quantity)
        : this(productId, itemId, productName, description, image, price, businessId, itemType, amountInStock)
        {
            Quantity = quantity;
        }
    }

}
