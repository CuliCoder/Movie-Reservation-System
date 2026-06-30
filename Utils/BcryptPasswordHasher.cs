namespace Movie_Reservation_System.Utils;
public class BcryptPasswordHasher : IPasswordHasher
{
    private const int WorkFactor = 12; // cost factor, tăng = chậm hơn = bảo mật hơn

    public string Hash(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password không được rỗng.");

        return BCrypt.Net.BCrypt.EnhancedHashPassword(password, WorkFactor);
    }

    public bool Verify(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash))
            return false;

        return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}