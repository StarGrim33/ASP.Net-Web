namespace OnlineShop.Db.Models
{
    public class CompareServices
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Service Service { get; set; }
    }
}
