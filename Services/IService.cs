namespace Movie_Reservation_System.Services;

public interface IService<T, TRequest, TResponse, TKey>
{
    Task<IEnumerable<TResponse>> GetAllAsync(CancellationToken ct = default);
    Task<TResponse?> GetByIdAsync(TKey id, CancellationToken ct = default);
    Task<TResponse> AddAsync(TRequest request, CancellationToken ct = default);
    Task<TResponse> UpdateAsync(TRequest request, CancellationToken ct = default);
    Task<bool> DeleteAsync(TKey id, CancellationToken ct = default);
}
