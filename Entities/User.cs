using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Web_API_Creation.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }
  
    public string Name { get; set; }
    public required string Email { get; set; }
    
    public required string Password { get; set; }
    
    public string Contact { get; set; }
}