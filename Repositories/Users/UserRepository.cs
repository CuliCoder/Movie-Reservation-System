namespace Movie_Reservation_System.Repositories.Users;

public class UserRepository(AppDbContext context) : BaseRepository<User, Guid>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, ct);
    }

    public async Task<bool> IsEmailTakenAsync(string email, CancellationToken ct = default)
    {
        return await _dbSet.AsNoTracking().AnyAsync(u => u.Email == email, ct);
    }
}