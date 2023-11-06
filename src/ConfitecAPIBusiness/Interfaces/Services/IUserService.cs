using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Models;

namespace ConfitecAPIBusiness.Interfaces.Services;

public interface IUserService : IDisposable
{
    Task<User> CreateAsync(UserCreateDTO payload);
    Task UpdateAsync(int id, UserUpdateDTO payload);
    Task<User?> ListByIdAsync(int id);
    Task<IEnumerable<User>> ListAllAsync();
    Task DeleteAsync(int id);
}