using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class Service
    {
        public Service()
        {
            CartItems = new List<CartItem>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string? Link { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
