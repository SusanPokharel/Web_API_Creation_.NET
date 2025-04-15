using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Web_API_Creation.DTOs;
using Web_API_Creation.Entities;
using Web_API_Creation.Repositories;

namespace Web_API_Creation.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
    
    public bool AddUser(UserDTO userDto)
    {
        var newUser = new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
            Contact = userDto.Contact,
        };
        _userRepository.InsertUser(newUser);
        return true;
    }
    
    public User? GetUserByEmail(string email)
    {
        return _userRepository.GetUserByEmail(email);
    }

    public bool UpdateUserByEmail(string email, UserDTO updatedUser)
    {
        var existingUser = _userRepository.GetUserByEmail(email);
        if (existingUser == null)
            return false;
        existingUser.Name = updatedUser.Name;
        existingUser.Email = updatedUser.Email;
        existingUser.Password = updatedUser.Password;
        existingUser.Contact = updatedUser.Contact;
        _userRepository.UpdateUser(existingUser);
        return true;
    }

    public bool DeleteUserByEmail(string email)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user == null)
            return false;
        _userRepository.DeleteUser(user);
        return true;
    }
    
}




