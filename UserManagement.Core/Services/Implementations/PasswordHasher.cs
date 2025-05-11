using System.Text;
using UserManagement.Core.Services.Interfaces;

namespace UserManagement.Core.Services.Implementations;

public class PasswordHasher(IHasher hasher) : IPasswordHasher
{
    public byte[] HashPassword(byte[] userSalt, string userPlainPassword)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(userPlainPassword);
        byte[] passwordWithSalt = [.. passwordBytes, .. userSalt];

        byte[] hashedPassword = hasher.Hash(passwordWithSalt);

        return hashedPassword;
    }
}