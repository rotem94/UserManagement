using UserManagement.Core.Responses;

namespace UserManagement.Core.Mappers.Interfaces;

public interface IJsonTokenMapper
{
    JsonToken MapStringToJsonToken(string str);
}