namespace Movie_Reservation_System.Models;

public class Showtime
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public Guid RoomId { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public decimal BasePrice { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
}
