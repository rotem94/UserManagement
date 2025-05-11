using System.Security.Cryptography;
using UserManagement.Core.Services.Interfaces;

namespace UserManagement.Core.Services.Implementations;

public class Hasher : IHasher
{
    public byte[] Hash(byte[] passwordWithSalt)
    {
        byte[] hash = SHA256.HashData(passwordWithSalt);

        return hash;
    }
}