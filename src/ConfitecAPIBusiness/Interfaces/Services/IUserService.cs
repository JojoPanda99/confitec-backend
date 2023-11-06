using ConfitecAPIBusiness.Models;

namespace ConfitecAPIBusiness.Interfaces.Services;

public interface IUserService : IDisposable
{
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task<User?> ListByIdAsync(int id);
    Task<IEnumerable<User>> ListAllAsync();
    Task DeleteAsync(int id);
}