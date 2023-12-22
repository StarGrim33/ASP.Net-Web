namespace OnlineShop.Db.Models
{
    public class FavouriteServices
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Service Service { get; set; }
    }
}
