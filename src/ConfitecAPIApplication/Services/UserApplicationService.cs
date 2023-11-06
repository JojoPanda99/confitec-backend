using AutoMapper;
using ConfitecAPIApplication.Interfaces;
using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Interfaces.Services;
using ConfitecAPIBusiness.Models;

namespace ConfitecAPIApplication.Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserApplicationService(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<UserByIdDTO?> ListByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDTO>> ListAllAsync()
    {

        var users = await _userService.ListAllAsync();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _userService.Dispose();
    }
}