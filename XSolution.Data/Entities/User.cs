namespace XSolution.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public bool? IsAgreeToWorkForFood {get; set;}
        public DateTime DateRegistration {get; set;}
        public bool IsBlocked { get; set; }


        public Country Country { get; set; }
        public CountryProvince Province { get; set; }
    }
}
