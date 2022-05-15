namespace PromotionEngine.Exception
{
    using System;
    public class CartException : ApplicationException
    {
        public CartException() { }

        public CartException(string message) : base(message) { }
    }
}
