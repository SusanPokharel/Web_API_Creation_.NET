using Web_API_Creation.DTOs;
using Web_API_Creation.Entities;

namespace Web_API_Creation.Services;

public interface IUserService
{
    public bool AddUser(UserDTO userDto);   
 
    public User? GetUserByEmail(string email);

    public bool UpdateUserByEmail(string email, UserDTO updatedUser);

    public List<User> GetAllUsers();

    public bool DeleteUserByEmail(string email);
}