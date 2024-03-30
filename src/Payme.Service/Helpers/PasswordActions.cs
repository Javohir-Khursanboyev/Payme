using System.Security.Cryptography;
using System.Text;

namespace Payme.Service.Helpers;

public class PasswordActions
{
    public static string Hashing(string password)
    {
        using (SHA256 hash = SHA256.Create())
        {
            byte[] hashedBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
