using Web_API_Creation.Entities;

namespace Web_API_Creation.Repositories;

public interface IUserRepository
{
 public void InsertUser(User newUser);   
 
 public User? GetUserByEmail(string email);

 public void UpdateUser(User user);

 public List<User> GetAllUsers();

 public void DeleteUser(User user);
}