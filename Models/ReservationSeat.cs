namespace Movie_Reservation_System.Models;

public class ReservationSeat
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid SeatId { get; set; }
    public Guid ShowtimeId { get; set; }
    public decimal PriceAtBooking { get; set; }

    // Navigation properties
    public Reservation Reservation { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
    public Showtime Showtime { get; set; } = null!;
}
