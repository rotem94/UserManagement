using System.Security.Cryptography;
using UserManagement.Core.Interfaces.Providers;

namespace UserManagement.Core.Providers;

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