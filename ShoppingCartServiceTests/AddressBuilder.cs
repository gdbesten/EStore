using ShoppingCartService.Models;

namespace ShoppingCartServiceTests
{
    public class AddressBuilder
    {
        private string _street;
        private string _city;
        private string _country;

        public AddressBuilder()
        {
            _street = "";
            _city = "";
            _country = "";
        }
        public AddressBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }

        public Address Build()
        {
            return new Address{
                Street = _street, 
                City = _city, 
                Country = _country};
        }
    }
}