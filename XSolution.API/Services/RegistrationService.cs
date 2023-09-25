using Microsoft.EntityFrameworkCore;
using XSolution.Data;
using XSolution.Data.Entities;
using XSolution.Data.IncomingModels;


namespace XSolution.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private DataBaseContext _dbContext;

        public RegistrationService(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public Task<List<KeyValuePair<int, string>>> GetAllCountries() => _dbContext.Countries
            .AsNoTracking()
            .Select(x => new KeyValuePair<int, string>(x.Id, x.Name))
            .ToListAsync();

        public Task<List<KeyValuePair<int, string>>> GetProvincesByCountryId(int id) => _dbContext.CountryProvinces
           .AsNoTracking()
           .Where(x => x.CountryId == id)
           .Select(x => new KeyValuePair<int, string>(x.Id, x.ProvinceName))
           .ToListAsync();

        public async Task<User> NewUserRegistration(UserIncoming model)
        {
            User newUser = new User
            {
                Login = model.Login,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                CountryId = model.CountryId,
                ProvinceId = model.ProvinceId,
                IsAgreeToWorkForFood = model.IsAgreeToWorkForFood,
                DateRegistration = DateTime.UtcNow
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }



    }
}
