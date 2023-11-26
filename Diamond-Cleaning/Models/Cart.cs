using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Models
{
    public class Cart
    {
        public List<CartItem> Items;

        public Cart()
        {
            Items = [];
        }

        public Guid Id {get; set;} // UserGuid

        public string UserId { get; set;}

        public decimal Cost
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }
    }
}
