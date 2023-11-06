using ConfitecAPIBusiness.Models;

namespace ConfitecAPIBusiness.Interfaces.Repositories;

public interface IRepository<T> : IDisposable where T : BaseEntity
{
    Task<List<T>> FindAllNoTrackingAsync();
    Task<T?> FindByIdAsync(int id);
    Task CreateAsync(T data);
    Task UpdateAsync(T data);
    Task RemoveAsync(int id);
    Task<bool> ExistsAnyByIdAsync(int id);
    Task<int> SaveChangesAsync();
}