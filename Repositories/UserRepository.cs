using Web_API_Creation.Entities;

namespace Web_API_Creation.Repositories;

public class UserRepository: IUserRepository 
{
    private ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }
    
    public void InsertUser(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }
    
    public User? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}