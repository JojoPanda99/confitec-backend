using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Models;

namespace ConfitecAPIApplication.Interfaces;

public interface IUserApplicationService : IDisposable
{
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task<UserByIdDTO?> ListByIdAsync(int id);
    Task<IEnumerable<UserDTO>> ListAllAsync();
    Task DeleteAsync(int id);
}