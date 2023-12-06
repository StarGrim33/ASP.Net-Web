namespace Diamond_Cleaning.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public UserOrderInfo User { get; set; }

        public List<CartItem> Items { get; set; }
    }
}
