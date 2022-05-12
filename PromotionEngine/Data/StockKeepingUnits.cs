namespace PromotionEngine.Data
{
    using PromotionEngine.Model;
    using System.Collections.Generic;
    using System.Linq;

    public static class StockKeepingUnits
    {
        public static readonly ICollection<Product> products = new List<Product>()
        {
            new Product() { Name = "A", Price = 50.00},
            new Product() { Name = "B", Price = 30.00},
            new Product() { Name = "C", Price = 20.00},
            new Product() { Name = "D", Price = 15.00}
        };        

        public static bool IsProductAvailable(string productName)
        {
            return products.Any(x => x.Name.Equals(productName));
        }

        public static Product GetProduct(string productName)
        {
            return products.Where(x => x.Name.Equals(productName)).FirstOrDefault();
        }
    }
}
