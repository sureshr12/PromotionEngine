namespace PromotionEngine.Rules
{
    using System.Linq;
    using PromotionEngine.Interface;
    using PromotionEngine.Model;

    /// <summary>
    /// Apply rule 2 of B's for 45 
    /// </summary>
    public class SecondProductRule : IProductRule
    {
        private const string productName = "B";

        public Cart Execute(Cart cart)
        {
            var productB = cart.Products.FirstOrDefault(p => p.Name.Equals(productName));
            if (productB != null)
            {
                productB.Discount = productB.TotalPrice - (productB.Quantity / 2 * 45 + productB.Quantity % 2 * productB.Price);
            }

            return cart;
        }
    }
}
