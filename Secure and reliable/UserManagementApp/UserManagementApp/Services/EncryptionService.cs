using System;
using System.Security.Cryptography;
using System.Text;

namespace UserManagementApp.Services
{
    public class EncryptionService
    {
        private static readonly byte[] Key =
            Encoding.UTF8.GetBytes("1234567890123456");
        private static readonly byte[] IV =
            Encoding.UTF8.GetBytes("6543210987654321");

        public string Encrypt(string data)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(data);
                    byte[] encrypted =
                        encryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                    return Convert.ToBase64String(encrypted);
                }
            }
        }

        public string Decrypt(string data)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (var decryptor = aes.CreateDecryptor())
                {
                    byte[] bytes = Convert.FromBase64String(data);
                    byte[] decrypted =
                        decryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                    return Encoding.UTF8.GetString(decrypted);
                }
            }
        }
    }
}
