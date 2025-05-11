namespace UserManagement.Core.Interfaces.Providers;

public interface IRandomBytesProvider
{
    byte[] GetRandomBytes();
}