namespace Movie_Reservation_System.Models;

public class Room
{
    public Guid Id { get; set; }
    public Guid TheaterId { get; set; }
    public required string Name { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }

    // Navigation properties
    public Theater Theater { get; set; } = null!;
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
