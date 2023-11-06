using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Repositories;
using ConfitecAPIBusiness.Models;
using ConfitecAPIData.Context;
using Microsoft.EntityFrameworkCore;

namespace ConfitecAPIData.Repository;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    private ConfitecApiContext _context;
    protected DbSet<T> DbSet { get; }

    protected BaseRepository(ConfitecApiContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }


    public virtual async Task<List<T>> FindAllNoTrackingAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> FindByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task CreateAsync(T data)
    {
        await DbSet.AddAsync(data);
        await SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T data)
    {
        DbSet.Update(data);
        await SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(int id)
    {
        DbSet.Remove(new T { Id = id });
        await SaveChangesAsync();
    }

    public async Task<bool> ExistsAnyByIdAsync(int id)
    {
        return await DbSet.AsNoTracking().AnyAsync(e => e.Id == id);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}