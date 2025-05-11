using UserManagement.Core.Responses;

namespace UserManagement.Core.Interfaces.Mappers;

public interface IJsonTokenMapper
{
    JsonToken MapStringToJsonToken(string str);
}