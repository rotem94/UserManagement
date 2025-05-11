namespace UserManagement.Core.Services.Interfaces;

public interface IHasher
{
    byte[] Hash(byte[] passwordWithSalt);
}