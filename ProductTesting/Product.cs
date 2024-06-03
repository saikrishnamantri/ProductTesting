using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTesting
{
    internal class Product
    {
        //Creating Properties
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        //Creating Contructor 
        public Product(int productId, string productName, double price, int stock)
        {
            if (productId < 1 || productId > 5000)
                throw new ArgumentException("ProductID should be between 1 and 5000");
            if (string.IsNullOrEmpty(productName))
                throw new ArgumentException("Enter a Valid Product Name");
            if (price < 1 || price > 10000)
                throw new ArgumentException("Price range should be in 1 and 10000");
            if (stock < 1 || stock > 5000)
                throw new ArgumentException("Stock should not exceed 5000");

            ProductId = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        //Creating Method to Increase Stock
        public void IncreaseTheStock(int quantity)
        {
            Stock += quantity;
        }

        //Creating Method to Decrease Stock
        public void DecreaseTheStock(int quantity)
        {
            if (Stock >= quantity)
            {
                Stock -= quantity;
            }
            else
            {
                throw new InvalidOperationException("Invalid Stock");
            }
        }
    }
}
