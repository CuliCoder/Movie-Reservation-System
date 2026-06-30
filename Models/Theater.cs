namespace Movie_Reservation_System.Models;

public class Theater
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }

    // Navigation properties
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
