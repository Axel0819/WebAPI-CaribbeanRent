using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Helpers
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            var sha= SHA256.Create();
            var passwordsBytes= Encoding.Default.GetBytes(password);
            var hashPassword= sha.ComputeHash(passwordsBytes);
            return Convert.ToBase64String(hashPassword);
        }
    }
}
