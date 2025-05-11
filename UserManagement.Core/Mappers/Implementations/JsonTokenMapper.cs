using UserManagement.Core.Mappers.Interfaces;
using UserManagement.Core.Responses;

namespace UserManagement.Core.Mappers.Implementations;

public class JsonTokenMapper : IJsonTokenMapper
{
    public JsonToken MapStringToJsonToken(string str)
    {
        JsonToken token = new();

        token.JwtToken = str;

        return token;
    }
}