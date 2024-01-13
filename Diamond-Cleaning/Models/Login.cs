namespace Diamond_Cleaning.Models
{
    public class Login
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
