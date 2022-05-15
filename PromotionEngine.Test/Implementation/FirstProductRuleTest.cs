namespace PromotionEngine.Test.Implementation
{
    using Xunit;   
    using System.Collections.Generic;
    using PromotionEngine.Rules;
    using PromotionEngine.Model;

    [Collection("Sequential")]
    public class FirstProductRuleTest
    {
        private readonly FirstProductRule underTest;
        private Cart cart;
        public FirstProductRuleTest()
        {
            underTest = new FirstProductRule(); 
        }

        [Fact]
        public void RuleShouldBeApplied_WhenValidProduct()
        {
            cart = new Cart()
            {
                Products = new List<Product>()
                {
                    new Product(){ Name="A", Price=50, Quantity=3}
                }
            };
            var actualCart = underTest.Execute(cart);
            Assert.Equal(130, actualCart.TotalPrice);
            Assert.Equal(20, actualCart.DiscountPrice);
        }

        [Fact]
        public void RuleShouldNotBeApplied_WhenInValidProduct()
        {
            cart = new Cart()
            {
                Products = new List<Product>()
                {
                    new Product(){ Name="B", Price=30, Quantity=3}
                }
            };
            var actualCart = underTest.Execute(cart);
            Assert.Equal(90, actualCart.TotalPrice);
            Assert.Equal(0, actualCart.DiscountPrice);
        }

    }
}
