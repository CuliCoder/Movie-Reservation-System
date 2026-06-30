namespace Movie_Reservation_System.Services.Users;

public class UserService(IUserRepository userRepository, IPasswordHasher passwordHasher) : BaseService<User, UserRequest, UserResponse, Guid>(userRepository), IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    protected override UserResponse ToResponse(User entity)
    {
        return new UserResponse(
            entity.Id,
            entity.Email,
            entity.FullName,
            entity.Role,
            entity.IsActive
        );
    }
    protected override User ToEntity(UserRequest request)
    {
        return new User
        {
            Email = request.Email!,
            PasswordHash = request.Password!,
            FullName = request.FullName,
            Role = request.Role!,
        };
    }
    public async Task<UserResponse> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        User? user = await _userRepository.GetByEmailAsync(email, ct);
        return user is not null ? ToResponse(user): null!;
    }

    public async Task<bool> IsEmailTakenAsync(string email, CancellationToken ct = default)
    {
        return await _userRepository.IsEmailTakenAsync(email, ct);
    }
    public override async Task<UserResponse> AddAsync(UserRequest userRequest, CancellationToken ct = default)
    {
        User user = ToEntity(userRequest);
        if (await IsEmailTakenAsync(user.Email, ct))
        {
            throw new Utils.DbUpdateException("Email đã tồn tại.");
        }
        user.PasswordHash = _passwordHasher.Hash(user.PasswordHash);
        User userRes = await _userRepository.AddAsync(user, ct);
        await _userRepository.SaveChangesAsync(ct);
        return ToResponse(userRes);
    }
    public override async Task<UserResponse> UpdateAsync(UserRequest userRequest, CancellationToken ct = default)
    {
        User user = ToEntity(userRequest);
        if (await IsEmailTakenAsync(user.Email, ct))
        {
            throw new Utils.DbUpdateException("Email đã tồn tại.");
        }
        user.PasswordHash = _passwordHasher.Hash(user.PasswordHash);
        User userRes = await _userRepository.UpdateAsync(user, ct);
        await _userRepository.SaveChangesAsync(ct);
        UserResponse userResponse = new UserResponse(
            userRes.Id,
            userRes.Email,
            userRes.FullName,
            userRes.Role,
            userRes.IsActive
        );
        return userResponse;
    }
}