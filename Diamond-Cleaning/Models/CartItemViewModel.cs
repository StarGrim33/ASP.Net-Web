namespace Diamond_Cleaning.Models
{
    public class CartItemViewModel
    {
        public Guid Id {  get; set;}

        public ServiceViewModel Service { get; set;}

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
