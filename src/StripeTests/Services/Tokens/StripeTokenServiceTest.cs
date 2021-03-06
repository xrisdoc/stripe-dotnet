namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class StripeTokenServiceTest : BaseStripeTest
    {
        private const string TokenId = "tok_123";

        private StripeTokenService service;
        private StripeTokenCreateOptions createOptions;

        public StripeTokenServiceTest()
        {
            this.service = new StripeTokenService();

            this.createOptions = new StripeTokenCreateOptions
            {
                Card = new StripeCreditCardOptions
                {
                    AddressCity = "City",
                    AddressCountry = "US",
                    AddressLine1 = "Line 1",
                    AddressLine2 = "Line 2",
                    AddressState = "CA",
                    AddressZip = "90210",
                    Cvc = "123",
                    ExpirationMonth = 10,
                    ExpirationYear = DateTime.Now.Year + 1,
                    Name = "Name",
                    Number = "4242424242424242",
                },
            };
        }

        [Fact]
        public void Create()
        {
            var token = this.service.Create(this.createOptions);
            Assert.NotNull(token);
            Assert.Equal("token", token.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var token = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(token);
            Assert.Equal("token", token.Object);
        }

        [Fact]
        public void Get()
        {
            var token = this.service.Get(TokenId);
            Assert.NotNull(token);
            Assert.Equal("token", token.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var token = await this.service.GetAsync(TokenId);
            Assert.NotNull(token);
            Assert.Equal("token", token.Object);
        }
    }
}
