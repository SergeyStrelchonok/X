using XSolution.Data.Entities;
using XSolution.Data.IncomingModels;

namespace XSolution.API.Services
{
    public interface IRegistrationService
    {
        Task<List<KeyValuePair<int, string>>> GetAllCountries();
        Task<List<KeyValuePair<int, string>>> GetProvincesByCountryId(int id);
        Task<User> NewUserRegistration(UserIncoming model);
    }
}
