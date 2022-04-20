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
            var address = new Address
            {
                Street = "Street",
                City = "City",
                Country = "Country"
            };

            // Act
            var result = _addressValidator.IsValid(address);

            // Assert
            Assert.True(result);
        }
    }
}
