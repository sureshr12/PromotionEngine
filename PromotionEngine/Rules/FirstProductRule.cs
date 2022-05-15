namespace PromotionEngine.Rules
{
    using System.Linq;
    using PromotionEngine.Interface;
    using PromotionEngine.Model;

    /// <summary>
    /// Apply promo if 3 of A's for 130
    /// </summary>
    public class FirstProductRule : IProductRule
    {
        private const string productName = "A";

        public Cart Execute(Cart cart)
        {
            var productA = cart.Products.FirstOrDefault(p => p.Name.Equals(productName));
            if(productA != null)
            {
                productA.Discount = productA.TotalPrice - (productA.Quantity / 3 * 130 + productA.Quantity % 3 * productA.Price);
            }

            return cart;
        }
    }
}
