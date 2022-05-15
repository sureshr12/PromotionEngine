namespace PromotionEngine.Test.Implementation
{
    using PromotionEngine.Exception;
    using PromotionEngine.Implementation;
    using System.Linq;
    using Xunit;

    [Collection("Sequential")]
    public class CheckoutTest
    {
        private readonly Checkout underTest;
        public CheckoutTest()
        {
            underTest = new Checkout();
        }

        [Fact]
        public void ScannedItem_ShouldAddToCart_WhenValidProduct()
        {           
            underTest.Scan("A");
            Assert.Equal(1, underTest.cart.Products.Count);
            Assert.Equal(50, underTest.cart.Products.Where(x => x.Name.Equals("A")).FirstOrDefault().TotalPrice);
        }

        [Fact]
        public void ScannedItem_ShouldNotAddToCart_WhenInValidProduct()
        {
            Assert.Throws<CartException>(() => underTest.Scan("E"));
            Assert.Equal(0, underTest.cart.Products.Count);
        }

        [Fact]
        public void ScannedItems_ShouldAddToCart_WhenValidProduct()
        {
            underTest.Scan("A");
            underTest.Scan("B");
            underTest.Scan("C");
            underTest.Scan("D");
            Assert.Equal(4, underTest.cart.Products.Count);
        }

        [Fact]
        public void MultipleScannedItems_ShouldAddToCart_WhenValidProduct()
        {
            underTest.Scan("A");
            underTest.Scan("A");
            underTest.Scan("A");
            underTest.Scan("B");
            Assert.Equal(2, underTest.cart.Products.Count);
            Assert.Equal(3, underTest.cart.Products.Where(x => x.Name.Equals("A")).FirstOrDefault().Quantity);
            Assert.Equal(150, underTest.cart.Products.Where(x => x.Name.Equals("A")).FirstOrDefault().TotalPrice);
            Assert.Equal(1, underTest.cart.Products.Where(x => x.Name.Equals("B")).FirstOrDefault().Quantity);
            Assert.Equal(30, underTest.cart.Products.Where(x => x.Name.Equals("B")).FirstOrDefault().TotalPrice);
        }
       
    }
}
