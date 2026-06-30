namespace Movie_Reservation_System.Utils;
public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string hash);
}