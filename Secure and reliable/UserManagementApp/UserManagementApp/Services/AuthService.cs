using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using UserManagementApp.Models;

namespace UserManagementApp.Services
{
    public class AuthService
    {
        private List<User> users = new List<User>();
        private EncryptionService encryption = new EncryptionService();

        public void Register(string username, string password, string email)
        {
            try
            {
                User user = new User
                {
                    Username = username,
                    HashedPassword = PasswordHasher.HashPassword(password),
                    EncryptedEmail = encryption.Encrypt(email)
                };

                users.Add(user);
                Log.Information("User registered: {Username}", username);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Registration error");
                throw new ApplicationException("Registration failed");
            }
        }

        public bool Login(string username, string password)
        {
            try
            {
                string hashed = PasswordHasher.HashPassword(password);

                return users.Any(u =>
                    u.Username == username &&
                    u.HashedPassword == hashed);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Login error");
                return false;
            }
        }
    }
}
