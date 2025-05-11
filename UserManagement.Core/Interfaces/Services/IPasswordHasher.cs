namespace UserManagement.Core.Interfaces.Services;

public interface IPasswordHasher
{
    byte[] HashPassword(byte[] userSalt, string userPlainPassword);
}