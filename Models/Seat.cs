namespace Movie_Reservation_System.Models;

public class Seat
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public required string RowLabel { get; set; }
    public int SeatNumber { get; set; }
    public required string SeatType { get; set; } // 'Standard' / 'VIP'

    // Navigation properties
    public Room Room { get; set; } = null!;
    public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
}
