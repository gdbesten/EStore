using ShoppingCartService.BusinessLogic.Validation;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class AddressValidatorTest
    {
        private readonly AddressValidator _addressValidator;

        public AddressValidatorTest()
        {
            _addressValidator = new AddressValidator();
        }

        [Fact]
        public void IsValidNullAddressResultIsFalse()
        {
            // Arrange, Given
            Address address = null;

            // Act, When
            var result = _addressValidator.IsValid(address);

            // Assert, Then
            Assert.False(result);
        }

        [Fact]
        public void IsValidIncompleteAddressIsFalse()
        {
            // Arrange
            var address = new Address();

            // Act
            var result = _addressValidator.IsValid(address);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidCompleteAddressResultIsTrue()
        {
            // Arrange
            var address = new AddressBuilder()
                .WithStreet("Street")
                .WithCity("City")
                .WithCountry("Street")
                .Build();
            // {
            //     Street = "Street",
            //     City = "City",
            //     Country = "Country"
            // };

            // Act
            var result = _addressValidator.IsValid(address);

            // Assert
            Assert.True(result);
        }

        [InlineData(null, null, null, false)]
        [InlineData("street", null, null, false)]
        [InlineData(null, "city", null, false)]
        [InlineData(null, null, "country", false)]
        [InlineData("street", "city", "country", true)]
        [Theory]
        public void AdressValidationTest(
            string street,
            string city,
            string country,
            bool validationResult)
        {
            // Arrange
            var address = new Address
            {
                Street = street,
                City = city,
                Country = country
            };

            // Act
            var result = _addressValidator.IsValid(address);

            // Assert
            Assert.Equal(validationResult, result);
        }

    }
}
