namespace Diamond_Cleaning.Models
{
    public class Service
    {
        private static int _instanceId = 0;

        public Service(string? name, string? description, string? cost)
        {
            Id = _instanceId;
            Name = name;
            Description = description;
            Cost = cost;
            _instanceId += 1;
        }

        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public string? Cost { get; }

        public override string ToString()
        {
            return $"\n{Id}, \n{Name}, \n{Cost}, \n{Description}";
        }
    }
}
