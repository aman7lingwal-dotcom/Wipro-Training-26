using System;
using System.Security.Cryptography;
using System.Text;

namespace UserManagementApp.Services
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(
                    Encoding.UTF8.GetBytes(password)
                );

                return Convert.ToBase64String(bytes);
            }
        }
    }
}
