namespace Movie_Reservation_System.Services.Users;

public interface IUserService : IService<User, UserRequest, UserResponse, Guid>
{
    Task<UserResponse> GetByEmailAsync(string email, CancellationToken ct);
    Task<bool> IsEmailTakenAsync(string email, CancellationToken ct);
}