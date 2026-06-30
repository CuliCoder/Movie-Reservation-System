namespace Movie_Reservation_System.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<MovieGenre> MovieGenres { get; set; } = null!;
    public DbSet<Theater> Theaters { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Seat> Seats { get; set; } = null!;
    public DbSet<Showtime> Showtimes { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<ReservationSeat> ReservationSeats { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Genre
        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.Name)
            .IsUnique();

        // Movie
        modelBuilder.Entity<Movie>()
            .HasQueryFilter(m => !m.IsDeleted);

        // MovieGenre (Junction)
        modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });

        modelBuilder.Entity<MovieGenre>()
            .HasQueryFilter(mg => !mg.Movie.IsDeleted);

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

        // Seat
        modelBuilder.Entity<Seat>()
            .HasIndex(s => new { s.RoomId, s.RowLabel, s.SeatNumber })
            .IsUnique();

        // Showtime
        modelBuilder.Entity<Showtime>()
            .HasQueryFilter(st => !st.Movie.IsDeleted);

        modelBuilder.Entity<Showtime>()
            .HasIndex(st => new { st.RoomId, st.StartTime });

        // Reservation
        modelBuilder.Entity<Reservation>()
            .Property(r => r.RowVersion)
            .IsRowVersion(); // In Npgsql this maps to xmin

        // ReservationSeat (Junction)
        modelBuilder.Entity<ReservationSeat>()
            .HasIndex(rs => new { rs.ShowtimeId, rs.SeatId })
            .IsUnique(); // Prevent double booking same seat in same showtime
            
        modelBuilder.Entity<ReservationSeat>()
            .HasOne(rs => rs.Reservation)
            .WithMany(r => r.ReservationSeats)
            .HasForeignKey(rs => rs.ReservationId);
            
        modelBuilder.Entity<ReservationSeat>()
            .HasOne(rs => rs.Seat)
            .WithMany(s => s.ReservationSeats)
            .HasForeignKey(rs => rs.SeatId);
            
        modelBuilder.Entity<ReservationSeat>()
            .HasOne(rs => rs.Showtime)
            .WithMany(st => st.ReservationSeats)
            .HasForeignKey(rs => rs.ShowtimeId);
    }
}
