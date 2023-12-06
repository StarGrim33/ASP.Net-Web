namespace Diamond_Cleaning.Models
{
    public class Service
    {
        private static int _instanceId = 0;

        public Service(string? name, string? description, decimal cost, string? link)
        {
            Name = name;
            Description = description;
            Cost = cost;
            Link = link;
            Id = _instanceId;
            _instanceId += 1;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string? Link { get; set; }

        public override string ToString()
        {
            return $"\n{Id}, \n{Name}, \n{Cost}, \n{Description}";
        }
    }
}
