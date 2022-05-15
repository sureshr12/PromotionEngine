namespace PromotionEngine.Implementation
{
    using System;
    using System.Linq;
    using PromotionEngine.Data;
    using PromotionEngine.Exception;
    using PromotionEngine.Interface;
    using PromotionEngine.Model;

    public class Checkout : ICheckout
    {
        private readonly IPromotion _promo;
        public readonly Cart cart;

        public Checkout()
        {
            _promo = new Promotion();
            cart = new Cart();
        }

        public double GetTotalPrice()
        {
            if (cart.Products.Count == 0)
            {
                return 0;
            }

            _promo.Apply(cart);

            return cart.TotalPrice;
        }

        public void Scan(string item)
        {
            if (StockKeepingUnits.IsProductAvailable(item))
            {
                var product = cart.Products.FirstOrDefault(p => p.Name == item);
                if (product == null)
                {
                    var productData = StockKeepingUnits.GetProduct(item);
                    cart.Products.Add(new Product { Name = productData.Name, Price = productData.Price });
                }
                else
                {
                    product.Quantity += 1;
                }
            }
            else
            {
                throw new CartException($"Product{item} is not available. Please check with our customer care representative.");
            }
        }

    }
}
