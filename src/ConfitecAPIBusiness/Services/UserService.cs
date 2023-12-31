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

    public async Task<User> CreateAsync(User user)
    {
        if (!await UserIsValid(user))
            return null;
        await _userRepository.CreateAsync(user);
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        if (!await UserIsValid(user)) return;
        if (!await NotifyIfUserNotExists(user.Id)) return;

        var userDb = await ListByIdAsync(user.Id);

        userDb!.Name = user.Name;
        userDb.Surname = user.Surname;
        userDb.BirthDate = user.BirthDate;
        userDb.Email = user.Email;
        userDb.Education = user.Education;

        await _userRepository.UpdateAsync(userDb);
    }

    public async Task<User?> ListByIdAsync(int id)
    {
        if (!await NotifyIfUserNotExists(id))
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

    public async Task<bool> NotifyIfUserNotExists(int id)
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