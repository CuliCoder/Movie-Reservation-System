namespace Movie_Reservation_System.Models;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }

    // Navigation properties
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}
