namespace XSolution.Data.Entities
{
    public class CountryProvince
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string ProvinceName { get; set; }
        public bool IsAvailable { get; set; }

        public Country Country { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
