namespace Diamond_Cleaning.Models
{
    public class Service
    {
        private static int _instanceId = 0;

        public Service(string? name, string? description, decimal cost, string? link)
        {
            Id = _instanceId;
            Name = name;
            Description = description;
            Cost = cost;
            _instanceId += 1;
            Link = link;
        }

        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public decimal Cost { get; }

        public string? Link { get; }

        public override string ToString()
        {
            return $"\n{Id}, \n{Name}, \n{Cost}, \n{Description}";
        }
    }
}
