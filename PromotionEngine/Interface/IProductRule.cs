namespace PromotionEngine.Interface
{
    using PromotionEngine.Model;

    public interface IProductRule
    {
        Cart Execute(Cart cart);
    }
}
