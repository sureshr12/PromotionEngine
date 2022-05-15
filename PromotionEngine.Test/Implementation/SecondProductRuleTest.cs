

namespace PromotionEngine.Test.Implementation
{
    using Xunit;
    using System.Collections.Generic;
    using PromotionEngine.Rules;
    using PromotionEngine.Model;

    [Collection("Sequential")]
    public class SecondProductRuleTest
    {
        private readonly SecondProductRule underTest;
        private Cart cart;
        public SecondProductRuleTest()
        {
            underTest = new SecondProductRule();
        }

        [Fact]
        public void RuleShouldBeApplied_WhenValidProduct()
        {
            cart = new Cart()
            {
                Products = new List<Product>()
                {
                    new Product(){ Name="B", Price=30, Quantity=3}
                }
            };
            var actualCart = underTest.Execute(cart);
            Assert.Equal(75, actualCart.TotalPrice);
            Assert.Equal(15, actualCart.DiscountPrice);
        }

        [Fact]
        public void RuleShouldNotBeApplied_WhenInValidProduct()
        {
            cart = new Cart()
            {
                Products = new List<Product>()
                {
                    new Product(){ Name="C", Price=30, Quantity=3}
                }
            };
            var actualCart = underTest.Execute(cart);
            Assert.Equal(90, actualCart.TotalPrice);
            Assert.Equal(0, actualCart.DiscountPrice);
        }
    }
}
