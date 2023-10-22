using System;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Models;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{userId}")]
    public ActionResult<User> GetUser(Guid userId)
    {
        var user = _userService.GetUserById(userId);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        _userService.AddUser(user);
        if (_userService.SaveChanges())
        {
            return CreatedAtAction("GetUser", new { userId = user.uuid }, user);
        }
        return BadRequest("Failed to create user.");
    }

    [HttpPut("{userId}")]
    public ActionResult UpdateUser(Guid userId, User user)
    {
        var existingUser = _userService.GetUserById(userId);
        if (existingUser == null)
        {
            return NotFound();
        }
        user.uuid = existingUser.uuid;
        _userService.UpdateUser(user);
        if (_userService.SaveChanges())
        {
            return NoContent();
        }
        return BadRequest("Failed to update user.");
    }

    [HttpDelete("{userId}")]
    public ActionResult DeleteUser(Guid userId)
    {
        var existingUser = _userService.GetUserById(userId);
        if (existingUser == null)
        {
            return NotFound();
        }
        _userService.DeleteUser(userId);
        if (_userService.SaveChanges())
        {
            return NoContent();
        }
        return BadRequest("Failed to delete user.");
    }
}
