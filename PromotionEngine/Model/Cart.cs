namespace PromotionEngine.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class Cart
    {
        public Cart() => Products = new List<Product>();

        public ICollection<Product> Products { get; set;}

        public double TotalPrice => Products.Sum(p => p.TotalPrice);

        public double DiscountPrice => Products.Sum(p => p.Discount);
    }
}
