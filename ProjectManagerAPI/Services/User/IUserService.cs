using System;
using System.Collections.Generic;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers();
    User GetFullUserByUuid(Guid userId);
	UserDto GetUserById(Guid userId);
    UserDto AddUser(CreateUserDto user);
    void UpdateUser(User existingUser, UpdateUserDto user);
    void DeleteUser(Guid userId);
    bool SaveChanges();
}
