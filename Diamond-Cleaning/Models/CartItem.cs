namespace Diamond_Cleaning.Models
{
    public class CartItem
    {
        public Guid Id {  get; set;}

        public Service Service { get; set;}

        public int Amount { get; set;}

        public decimal Cost 
        { 
            get
            {
                return Service.Cost * Amount;
            }
        }
    }
}
