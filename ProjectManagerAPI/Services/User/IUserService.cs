using System;
using System.Collections.Generic;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers();
	UserDto GetUserById(Guid userId);
    UserDto AddUser(CreateUserDto user);
    void UpdateUser(UserDto user);
    void DeleteUser(Guid userId);
    bool SaveChanges();
}
