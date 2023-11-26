using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Models
{
    public class Cart
    {
        private List<Service> _services;

        public decimal TotalPrice { get; set; }

        public Guid Id {get; set;} // UserGuid

        public Cart()
        {
            _services = new();
        }

        public void AddItem(Service service)
        {
            try
            {
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
