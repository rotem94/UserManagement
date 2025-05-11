using System.Security.Cryptography;
using UserManagement.Core.Interfaces.Services;

namespace UserManagement.Core.Services;

public class Hasher : IHasher
{
    public byte[] Hash(byte[] passwordWithSalt)
    {
        byte[] hash = SHA256.HashData(passwordWithSalt);

        return hash;
    }
}