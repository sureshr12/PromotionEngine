namespace PromotionEngine.Model
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; } = 1;

        public double Discount { get; set; }

        public double TotalPrice => (Quantity * Price) - Discount;
    }
}
