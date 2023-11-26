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
    }
}
