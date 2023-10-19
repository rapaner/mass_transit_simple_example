namespace SharedModels
{
    public interface OrderResult
    {
        public int OrderId { get; }
        public string ProductName { get; }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}