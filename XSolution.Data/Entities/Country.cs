namespace XSolution.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<CountryProvince> Provinces { get; set; } = new List<CountryProvince>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
