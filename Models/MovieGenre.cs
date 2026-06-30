namespace Movie_Reservation_System.Models;

public class MovieGenre
{
    public Guid MovieId { get; set; }
    public int GenreId { get; set; }

    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
}
