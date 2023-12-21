using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Models
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items;

        public CartViewModel()
        {
            Items = [];
        }

        public Guid Id {get; set;} // UserGuid

        public string UserId { get; set;}

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public int Amount => Items?.Sum(x => x.Amount) ?? 0;
    }
}
