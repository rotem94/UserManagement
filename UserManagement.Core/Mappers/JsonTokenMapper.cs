using UserManagement.Core.Interfaces.Mappers;
using UserManagement.Core.Responses;

namespace UserManagement.Core.Mappers;

public class JsonTokenMapper : IJsonTokenMapper
{
    public JsonToken MapStringToJsonToken(string str)
    {
        JsonToken token = new();

        token.JwtToken = str;

        return token;
    }
}