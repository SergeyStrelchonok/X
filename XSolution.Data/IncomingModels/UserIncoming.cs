namespace XSolution.Data.IncomingModels
{
    public class UserIncoming
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public bool? IsAgreeToWorkForFood { get; set; }
    }
}
