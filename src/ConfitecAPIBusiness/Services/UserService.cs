using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Repositories;
using ConfitecAPIBusiness.Interfaces.Services;
using ConfitecAPIBusiness.Models;
using ConfitecAPIBusiness.Validations;

namespace ConfitecAPIBusiness.Services;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, INotificationHandler notificationHandler) : base(
        notificationHandler)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateAsync(UserCreateDTO payload)
    {
        var user = new User
        {
            Name = payload.Name,
            Surname = payload.Surname,
            Email = payload.Email,
            Education = payload.Education,
            BirthDate = payload.BirthDate
        };
        await _userRepository.CreateAsync(user);
        return user;
    }

    public async Task UpdateAsync(int id, UserUpdateDTO payload)
    {
        if (!await _userRepository.ExistsAnyByIdAsync(id))
        {
        }

        var userToPatch = new User
        {
            Id = id,
            Name = payload.Name,
            Surname = payload.Surname,
            Email = payload.Email,
            BirthDate = payload.BirthDate,
            Education = payload.Education
        };
        await _userRepository.UpdateAsync(userToPatch);
    }

    public async Task<User?> ListByIdAsync(int id)
    {
        if (!await _userRepository.ExistsAnyByIdAsync(id))
            return null;

        var user = await _userRepository.FindByIdAsync(id);
        return user;
    }

    public async Task<IEnumerable<User>> ListAllAsync()
    {
        return await _userRepository.FindAllNoTrackingAsync();
    }

    public async Task DeleteAsync(int id)
    {
        if (!await NotifyIfUserNotExists(id))
            return;
        await _userRepository.RemoveAsync(id);
    }

    private async Task<bool> UserIsValid(User user)
    {
        return await ValidateAsync(user, new UserValidation());
    }

    private async Task<bool> NotifyIfUserNotExists(int id)
    {
        var userExists = await _userRepository.ExistsAnyByIdAsync(id);
        if (!userExists)
            AddNotification("User not found");
        return userExists;
    }

    public void Dispose()
    {
        _userRepository.Dispose();
    }
}