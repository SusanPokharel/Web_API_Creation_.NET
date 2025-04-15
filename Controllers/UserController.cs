using Web_API_Creation.DTOs;
using Microsoft.AspNetCore.Mvc;
using Web_API_Creation.Services;

namespace Web_API_Creation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("get-all")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        
        [HttpPost("add-user")]
        public IActionResult AddUser([FromBody] UserDTO user)
        {
           var isUserCreated = _userService.AddUser(user);
           if (isUserCreated)
           {
               return Ok("User created");
           }
           return BadRequest("User not created");
        }
        
        [HttpGet("get-user/{email}")]
        public IActionResult GetUser(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user != null)
                return Ok(user);
            return NotFound("User not found");
        }

        [HttpPut("update-user/{email}")]
        public IActionResult UpdateUser(string email, [FromBody] UserDTO updatedUser)
        {
            var result = _userService.UpdateUserByEmail(email, updatedUser);
            if (result)
                return Ok("User updated");
            return NotFound("User not found");
        }

        [HttpDelete("delete-user/{email}")]
        public IActionResult DeleteUser(string email)
        {
            var result = _userService.DeleteUserByEmail(email);
            if (result)
                return Ok("User deleted");
            return NotFound("User not found");
        }
    }
}



















// using Web_API_Creation.DTOs;
// using Microsoft.AspNetCore.Mvc;
// namespace Web_API_Creation.Controllers
// {
//     
// [ApiController]
// [Route("[controller]")]
//
// public class UserController : ControllerBase
// {
//     private static List<UserDTO> userData = new List<UserDTO>();     
//         [HttpGet("get-all-users")]
//         public List<UserDTO> GetData()
//         {
//             return userData;
//         }
//
//
//
//         [HttpPost("add-user")]
//         public ActionResult<string> Add(UserDTO user) 
//         {
//             userData.Add(user);
//             return BadRequest("User added successfully");
//         }   
// }
// }
//
// // [HttpPost("add-user")]
// // public List<UserDTO> Add(UserDTO user)
// // {
// //     if (userData.Contains(name))
// //     {
// //         userData.Add(name); 
// //         return $"{name} added successfully";
// //     }
// //     return "Duplicate name" + $" {name} not added";
// // }
//
// //
// //
// // [HttpPut("uppdate user")]
// // public string PutData(UserDTO name, UserDTO newname)
// // {
// //     if (userData.Contains(name))
// //     {
// //         userData.Remove(name);
// //         userData.Add(newname);
// //     }
// //     return $"{name} renamed to" + $" {newname} successfully";
// // }