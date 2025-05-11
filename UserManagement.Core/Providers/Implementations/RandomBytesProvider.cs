using System.Security.Cryptography;
using UserManagement.Core;
using UserManagement.Core.Providers.Interfaces;

namespace UserManagement.Core.Providers.Implementations;

public class RandomBytesProvider : IRandomBytesProvider
{
    public byte[] GetRandomBytes()
    {
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();

        byte[] bytes = new byte[Constants.SaltSize];
        rng.GetBytes(bytes);

        return bytes;
    }
}