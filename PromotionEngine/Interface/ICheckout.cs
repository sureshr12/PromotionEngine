namespace PromotionEngine.Interface
{
    public interface ICheckout
    {
        void Scan(string item);
        double GetTotalPrice();
    }
}
