namespace Diamond_Cleaning.Models
{
    public class User
    {
        public User(string name)
        {
            Name = name;
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; set; }

        public string? Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string CheckBox { get; set; }

        public string RepeatPassword { get; set; }

        public bool DoRememberMe => CheckBox == "on";
    }
}
