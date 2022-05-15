namespace PromotionEngine.Test.Implementation
{    
    using Xunit;
    using PromotionEngine.Implementation;
    using PromotionEngine.Exception;

    [Collection("Sequential")]
    public class PromotionTest
    {
        private readonly Promotion underTest;
        public PromotionTest()
        {
            underTest = new Promotion();

        }

        [Fact]
        public void ScannedItem_ShouldAddToCart_WhenValidProduct()
        {
            Assert.Throws<CartException>(() => underTest.Apply(new Model.Cart()));
        }
    }
}
