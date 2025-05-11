namespace UserManagement.Core.Services.Interfaces;

public interface IPasswordHasher
{
    byte[] HashPassword(byte[] userSalt, string userPlainPassword);
}