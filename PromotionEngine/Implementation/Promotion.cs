namespace PromotionEngine.Implementation
{
    using System.Collections.Generic;
    using PromotionEngine.Exception;
    using PromotionEngine.Interface;
    using PromotionEngine.Model;

    /// <summary>
    /// Promotion rule engine
    /// </summary>
    public class Promotion : IPromotion
    {
        private readonly List<IProductRule> _rules = new List<IProductRule>();

        public Promotion()
        {
            ////Todo: Yet to add rules
        }

        public Cart Apply(Cart cart)
        {
            if (cart?.Products == null || cart.Products.Count == 0)
            {
                throw new CartException("Cart is empty.Promo rules not applied");
            }

            foreach (var rule in _rules)
            {
                cart = rule.Execute(cart);
            }

            return cart;
        }
    }
}
