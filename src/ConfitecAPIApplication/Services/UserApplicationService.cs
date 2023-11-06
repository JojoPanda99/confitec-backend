using AutoMapper;
using ConfitecAPIApplication.DTOs.User;
using ConfitecAPIApplication.Interfaces;
using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Services;
using ConfitecAPIBusiness.Models;
using ConfitecAPIBusiness.Notifications;

namespace ConfitecAPIApplication.Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly IUserService _userService;
    private readonly INotificationHandler _notificationHandler;
    private readonly IMapper _mapper;

    public UserApplicationService(IUserService userService,
        IMapper mapper,
        INotificationHandler notificationHandler)
    {
        _userService = userService;
        _mapper = mapper;
        _notificationHandler = notificationHandler;
    }

    public async Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var userDb = await _userService.CreateAsync(user);
        if (userDb != null)
            return _mapper.Map<CreateUserResponseDTO>(userDb);

        AddNotification("An error occurred while creating the user.");
        return null;
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserByIdDTO?> ListByIdAsync(int id)
    {
        var user = await _userService.ListByIdAsync(id);
        return _mapper.Map<UserByIdDTO>(user);
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

    private void AddNotification(string message)
    {
        _notificationHandler.Handler(new Notification(message));
    }

    public void Dispose()
    {
        _userService.Dispose();
    }
}