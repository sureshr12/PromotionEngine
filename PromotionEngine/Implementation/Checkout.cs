namespace PromotionEngine.Implementation
{
    using System;
    using System.Linq;
    using PromotionEngine.Data;
    using PromotionEngine.Interface;
    using PromotionEngine.Model;

    public class Checkout : ICheckout
    {
        public readonly Cart cart = new Cart();

        public int GetTotalPrice()
        {
            if (cart.Products.Count == 0) 
            {
                return 0;
            }

            //// TODO: Apply promo rules

            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            if (StockKeepingUnits.IsProductAvailable(item))
            {
                var product = cart.Products.FirstOrDefault(p => p.Name == item);
                if (product == null)
                {
                    cart.Products.Add(StockKeepingUnits.GetProduct(item));
                }
                else {
                    product.Quantity += 1;
                }
            }
        }

    }
}
