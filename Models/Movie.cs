namespace Movie_Reservation_System.Models;

public class Movie
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? PosterUrl { get; set; }
    public int DurationMinutes { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public required string Status { get; set; } // 'NowShowing' / 'ComingSoon' / 'Ended'
    public bool IsDeleted { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; }

    // Navigation properties
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
