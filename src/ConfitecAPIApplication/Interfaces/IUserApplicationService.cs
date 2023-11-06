using ConfitecAPIApplication.DTOs.User;
using ConfitecAPIBusiness.DTO;

namespace ConfitecAPIApplication.Interfaces;

public interface IUserApplicationService : IDisposable
{
    Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO user);
    Task UpdateAsync(UpdateUserDTO user);
    Task<UserByIdDTO?> ListByIdAsync(int id);
    Task<IEnumerable<UserDTO>> ListAllAsync();
    Task DeleteAsync(int id);
}