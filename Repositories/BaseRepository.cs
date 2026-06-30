using System.Data;
using Microsoft.EntityFrameworkCore;
using Movie_Reservation_System.Data;

namespace Movie_Reservation_System.Repositories;

public abstract class BaseRepository<T, TKey> : IRepository<T, TKey> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;
    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbSet.AsNoTracking().ToListAsync(ct);
    }

    public virtual async Task<T?> GetByIdAsync(TKey id, CancellationToken ct = default)
    {
        return await _dbSet.FindAsync([id], ct);
    }
    public virtual async Task<bool> ExistsAsync(TKey id, CancellationToken ct = default)
    {
        return await GetByIdAsync(id, ct) is not null;
    }
    public virtual async Task<T> AddAsync(T entity, CancellationToken ct = default)
    {
        await _dbSet.AddAsync(entity, ct);
        return entity;
    }

    public virtual Task<T> UpdateAsync(T entity, CancellationToken ct = default)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken ct = default)
    {
        T? entity = await _dbSet.FindAsync([id], ct);
        if (entity is null) return false;
        _dbSet.Remove(entity);
        return true;
    }
    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _context.SaveChangesAsync(ct);
    }
}