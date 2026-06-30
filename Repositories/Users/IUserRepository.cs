namespace Movie_Reservation_System.Repositories.Users;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    Task<bool> IsEmailTakenAsync(string email, CancellationToken ct);
}