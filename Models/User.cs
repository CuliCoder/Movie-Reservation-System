namespace Movie_Reservation_System.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public string? FullName { get; set; }
    public required string Role { get; set; } // 'Admin' / 'User'
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
public record UserResponse(Guid Id, string Email, string? FullName, string Role, bool IsActive);
public record UserRequest(string? Email, string? Password, string? FullName, string? Role);