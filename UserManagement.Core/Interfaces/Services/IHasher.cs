namespace UserManagement.Core.Interfaces.Services;

public interface IHasher
{
    byte[] Hash(byte[] passwordWithSalt);
}