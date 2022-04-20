using System.Collections.Generic;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class ShippingCalculatorTest
    {
        private readonly Address _address;
        private readonly ShippingCalculator _shippingCalculator;

        public ShippingCalculatorTest()
        {
            _address = new Address
            {
                Street = "Street",
                City = "City",
                Country = "Country"
            };
            _shippingCalculator = new ShippingCalculator(_address);
        }

        [Fact]
        public void SingleProductHappyTest()
        {
            // Arrange
            var cart = new Cart
            {
                CustomerType = CustomerType.Standard,
                ShippingAddress = _address,
                Items = new List<Item>
                {
                    new Item
                    {
                        ProductId = "0001",
                        ProductName = "Product 1",
                        Price = 10,
                        Quantity = 5
                    }
                }
            };

            // Act
            var result = _shippingCalculator.CalculateShippingCost(cart);

            // Assert, 5 * 1 = 5
            Assert.Equal(5, result);

        }
        [Fact]
        public void DoubleProductHappyTest()
        {
            // Arrange
            var cart = new Cart
            {
                CustomerType = CustomerType.Standard,
                ShippingAddress = _address,
                Items = new List<Item>
                {
                    new Item
                    {
                        ProductId = "0001",
                        ProductName = "Product 1",
                        Price = 10,
                        Quantity = 5
                    },
                    new Item
                    {
                        ProductId = "0002",
                        ProductName = "Product 2",
                        Price = 10,
                        Quantity = 15
                    }
                }
            };

            // Act
            var result = _shippingCalculator.CalculateShippingCost(cart);

            // Assert, 5 * 1 + 15 * 1 = 20
            Assert.Equal(20, result);

        }
    }
}
