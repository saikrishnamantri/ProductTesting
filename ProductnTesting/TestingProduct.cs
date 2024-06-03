using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTesting;

namespace ProductnTesting
{
    public class TestingProduct
    {
        [Test]
        public void Constructor_ValidInput_SetsPropertiesCorrectly()
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.5;
            int stock = 150;

            // Act
            Product product = new Product(productId, productName, price, stock);

            // Assert
            Assert.AreEqual(productId, product.ProductId);
            Assert.AreEqual(productName, product.ProductName);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(stock, product.Stock);
        }

        [TestCase(0)]
        [TestCase(5001)]
        public void ProductID_OutOfRange_ThrowsArgumentException(int productId)
        {
            // Arrange
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 150;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(productId, productName, price, stock));
        }

        [TestCase(1)]
        [TestCase(5000)]
        public void ProductID_ValidRange_SetsPropertyCorrectly(int productID)
        {
            // Arrange
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 150;

            // Act
            Product product = new Product(productID, productName, price, stock);

            // Assert
            Assert.AreEqual(productID, product.ProductId);
        }

        [Test]
        public void ProductName_NullOrEmpty_ThrowsArgumentException()
        {
            // Arrange
            int productId = 101;
            string productName = null;
            double price = 15.50;
            int stock = 150;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(productId, productName, price, stock));

            // Arrange
            productName = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(productId, productName, price, stock));
        }

        [Test]
        public void ProductName_ValidString_SetsPropertyCorrectly()
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 150;

            // Act
            Product product = new Product(productId, productName, price, stock);

            // Assert
            Assert.AreEqual(productName, product.ProductName);
        }

        [TestCase(0.99)]
        [TestCase(10000.01)]
        public void Price_OutOfRange_ThrowsArgumentException(double price)
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            int stock = 150;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(productId, productName, price, stock));
        }

        [TestCase(1.00)]
        [TestCase(5000.00)]
        public void Price_ValidRange_SetsPropertyCorrectly(double price)
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            int stock = 150;

            // Act
            Product product = new Product(productId, productName, price, stock);

            // Assert
            Assert.AreEqual(price, product.Price);
        }

        [TestCase(0)]
        [TestCase(5001)]
        public void Stock_OutOfRange_ThrowsArgumentException(int stock)
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.50;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(productId, productName, price, stock));
        }

        [TestCase(1)]
        [TestCase(5000)]
        public void Stock_ValidRange_SetsPropertyCorrectly(int stock)
        {
            // Arrange
            int productId = 123;
            string productName = "Sample Product";
            double price = 15.50;

            // Act
            Product product = new Product(productId, productName, price, stock);

            // Assert
            Assert.AreEqual(stock, product.Stock);
        }

        [Test]
        public void IncreaseStock_ValidQuantity_IncreasesStockCorrectly()
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 150;
            int increaseQuantity = 70;
            Product product = new Product(productId, productName, price, stock);

            // Act
            product.IncreaseTheStock(increaseQuantity);

            // Assert
            Assert.AreEqual(stock + increaseQuantity, product.Stock);
        }

        [Test]
        public void IncreaseStock_ZeroQuantity_DoesNotChangeStock()
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 130;
            int increaseQuantity = 0;
            Product product = new Product(productId, productName, price, stock);

            // Act
            product.IncreaseTheStock(increaseQuantity);

            // Assert
            Assert.AreEqual(stock, product.Stock);
        }

        [Test]
        public void DecreaseStock_ValidQuantity_DecreasesStockCorrectly()
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 100;
            int decreaseQuantity = 70;
            Product product = new Product(productId, productName, price, stock);

            // Act
            product.DecreaseTheStock(decreaseQuantity);

            // Assert
            Assert.AreEqual(stock - decreaseQuantity, product.Stock);
        }

        [Test]
        public void DecreaseStock_ZeroQuantity_DoesNotChangeStock()
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 150;
            int decreaseQuantity = 0;
            Product product = new Product(productId, productName, price, stock);

            // Act
            product.DecreaseTheStock(decreaseQuantity);

            // Assert
            Assert.AreEqual(stock, product.Stock);
        }

        [Test]
        public void DecreaseStock_InsufficientStock_ThrowsInvalidOperationException()
        {
            // Arrange
            int productId = 101;
            string productName = "Sample Product";
            double price = 15.50;
            int stock = 120;
            int decreaseQuantity = 150;
            Product product = new Product(productId, productName, price, stock);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseTheStock(decreaseQuantity));
        }

    }
}
