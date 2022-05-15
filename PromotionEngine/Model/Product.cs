namespace PromotionEngine.Model
{
    /// <summary>
    /// Product class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Product quantity 
        /// </summary>
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// Applied discount for the product
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// Product total amount
        /// </summary>
        public double TotalPrice => (Quantity * Price) - Discount;
    }
}
