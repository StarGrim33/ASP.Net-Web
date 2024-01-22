namespace Diamond_Cleaning.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        public string Phone { get; set; }

        public List<string> Roles { get; set; }
    }
}
