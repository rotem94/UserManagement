using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Core;
using UserManagement.Core.Interfaces.Services;
using UserManagement.Core.Models;
using UserManagement.Core.Requests;
using UserManagement.Core.Responses;

namespace UserManagement.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserManagementController(IUserService userService, IJwtGenerator jwtGenerator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<JsonToken>> RegisterAsync(UserInput userInput)
    {
        Result userRegisteredResult = await userService.RegisterUserAsync(userInput);

        if (userRegisteredResult.IsSuccess)
        {
            JsonToken jsonToken = jwtGenerator.GenerateJwt(userInput.Username);

            return StatusCode(userRegisteredResult.StatusCode, jsonToken);
        }
        else
        {
            return StatusCode(userRegisteredResult.StatusCode, userRegisteredResult.ErrorMessage);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<JsonToken>> LoginAsync(UserInput userInput)
    {
        Result<UserModel> userLoggedInResult = await userService.LoginUserAsync(userInput);

        if (userLoggedInResult.IsSuccess)
        {
            string username = userInput.Username;
            string role = userLoggedInResult.Value.Role;

            JsonToken jsonToken = jwtGenerator.GenerateJwt(username, role);

            return StatusCode(userLoggedInResult.StatusCode, jsonToken);
        }
        else
        {
            return StatusCode(userLoggedInResult.StatusCode, userLoggedInResult.ErrorMessage);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<Usernames>> GetAllUsernamesAsync()
    {
        Result<Usernames> usersResult = await userService.GetAllUsernamesAsync();

        if (usersResult.IsSuccess)
        {
            return StatusCode(usersResult.StatusCode, usersResult.Value);
        }
        else
        {
            return StatusCode(usersResult.StatusCode, usersResult.ErrorMessage);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{username}")]
    public async Task<ActionResult> DeleteUserAsync(string username)
    {
        Result userDeletedResult = await userService.DeleteUserAsync(username);

        if (userDeletedResult.IsSuccess)
        {
            return StatusCode(userDeletedResult.StatusCode);
        }
        else
        {
            return StatusCode(userDeletedResult.StatusCode, userDeletedResult.ErrorMessage);
        }
    }
}