namespace PromotionEngine.Test.Implementation
{    
    using Xunit;
    using System.Collections.Generic;
    using PromotionEngine.Implementation;
    using PromotionEngine.Exception;
    using PromotionEngine.Model;

    [Collection("Sequential")]
    public class PromotionTest
    {
        private readonly Promotion underTest;
        private Cart cart;
        public PromotionTest()
        {
            underTest = new Promotion();

        }

        [Fact]
        public void ShouldThrowsException_WhenCartIsNull()
        {
            Assert.Throws<CartException>(() => underTest.Apply(new Model.Cart()));
        }

        [Fact]
        public void FirstProductRuleShouldBeApplied_WhenValidProduct()
        {
            cart = new Cart()
            {
                Products = new List<Product>()
                {
                    new Product(){ Name="A", Price=50, Quantity=3}
                }
            };
            var actualCart = underTest.Apply(cart);
            Assert.Equal(130, actualCart.TotalPrice);
            Assert.Equal(20, actualCart.DiscountPrice);
        }

        [Fact]
        public void FirstProductRuleShouldBeApplied_WhenInValidProduct()
        {
            cart = new Cart()
            {
                Products = new List<Product>()
                {
                    new Product(){ Name="B", Price=30, Quantity=3}
                }
            };
            var actualCart = underTest.Apply(cart);
            Assert.Equal(90, actualCart.TotalPrice);
            Assert.Equal(0, actualCart.DiscountPrice);
        }

    }
}
