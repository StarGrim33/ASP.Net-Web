namespace OnlineShop.Db.Models
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public List<CartItem> Items { get; set; }

        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}
