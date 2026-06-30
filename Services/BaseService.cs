namespace Movie_Reservation_System.Services;

using Movie_Reservation_System.Repositories;

public abstract class BaseService<T, TRequest, TResponse, TKey> : IService<T, TRequest, TResponse, TKey> where T : class
{
    protected readonly IRepository<T, TKey> _repository;
    protected abstract TResponse ToResponse(T entity);
    protected abstract T ToEntity(TRequest request);

    public BaseService(IRepository<T, TKey> repository)
    {
        _repository = repository;
    }
    public virtual async Task<IEnumerable<TResponse>> GetAllAsync(CancellationToken ct = default)
    {
        IEnumerable<T> entities = await _repository.GetAllAsync(ct);
        return entities.Select(ToResponse).ToList();
    }
    public virtual async Task<TResponse?> GetByIdAsync(TKey id, CancellationToken ct = default)
    {
        T? entity = await _repository.GetByIdAsync(id, ct);
        return entity is not null ? ToResponse(entity) : default;
    }
    public virtual async Task<TResponse> AddAsync(TRequest request, CancellationToken ct = default)
    {
        T entity = ToEntity(request);
        await _repository.AddAsync(entity, ct);
        await _repository.SaveChangesAsync(ct);
        return ToResponse(entity);
    }
    public virtual async Task<TResponse> UpdateAsync(TRequest request, CancellationToken ct = default)
    {
        T entity = ToEntity(request);
        await _repository.UpdateAsync(entity, ct);
        await _repository.SaveChangesAsync(ct);
        return ToResponse(entity);
    }
    public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken ct = default)
    {
        bool deleted = await _repository.DeleteAsync(id, ct);
        if (deleted) await _repository.SaveChangesAsync(ct);
        return deleted;
    }
}