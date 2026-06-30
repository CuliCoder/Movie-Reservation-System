namespace Movie_Reservation_System.Models;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ShowtimeId { get; set; }
    public required string Status { get; set; } // 'Pending' / 'Confirmed' / 'Cancelled' / 'Expired'
    public decimal TotalPrice { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ConfirmedAt { get; set; }
    public DateTimeOffset? CancelledAt { get; set; }
    
    // Concurrency Token
    public uint RowVersion { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public Showtime Showtime { get; set; } = null!;
    public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
}
