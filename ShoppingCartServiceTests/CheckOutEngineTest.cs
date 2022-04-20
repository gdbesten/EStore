using System.Collections.Generic;
using AutoMapper;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Mapping;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class CheckOutEngineTest
    {
        private readonly Address _address;
        private readonly ShippingCalculator _shippingCalculator
            ;

        private readonly CheckOutEngine _checkOutEngine;
        private readonly IMapper _mapper;

        public CheckOutEngineTest()
        {
            _address = new Address
            {
                Street = "Street",
                City = "City",
                Country = "Country"
            };


            _shippingCalculator = new ShippingCalculator(_address);
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));

            _mapper = config.CreateMapper(); _checkOutEngine = new CheckOutEngine(_shippingCalculator, _mapper);
        }

        [Fact]
        public void StandardHappyTest()
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
            var result = _checkOutEngine.CalculateTotals(cart);

            // Assert, 5 * 10 + 5 = 55
            Assert.Equal(55, result.Total);

        }

        [Fact]
        public void PremiumHappyTest()
        {
            // Arrange
            var cart = new Cart
            {
                CustomerType = CustomerType.Premium,
                ShippingAddress = _address,
                Items = new List<Item>
                {
                    new Item
                    {
                        ProductId = "0001",
                        ProductName = "Product 1",
                        Price = 99,
                        Quantity = 5
                    }
                }
            };

            // Act
            var result = _checkOutEngine.CalculateTotals(cart);

            // Assert, 5 * 99 + 5 = 500 * 0.9 = 450
            Assert.Equal(450, result.Total);

        }
    }
}
