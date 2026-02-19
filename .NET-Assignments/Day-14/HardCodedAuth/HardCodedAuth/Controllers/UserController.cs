using AAApi.DTOs;
using AAApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController :ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserDTO dto)
        {
            // Check ModelState for validation errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objUser = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (objUser != null)
                return BadRequest("User already exists with this email");

            var newUser = new UserClass
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,  
                IsActive = true,
                LastModifiedTime = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();   

            return Ok(newUser);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var validUser = _context.Users.FirstOrDefault(u => 
            u.Email == dto.Email && u.Password == dto.Password);

            if(validUser == null)
                return Unauthorized("Invalid email or password");

            return Ok(new
            {
                User = validUser.Email
            });
        }
        [HttpGet("GetUserProfile/{userId}")]
        public IActionResult GetUserProfile(int userId)
        {
            var user = _context.Users
                       .Where(u => u.UserID == userId)
                       .Select(u => new UserResponseDTO
                       {
                            UserID = u.UserID,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            IsActive = u.IsActive
                       })
                       .FirstOrDefault();
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users
                        .Select(u => new UserResponseDTO
                        {
                            UserID = u.UserID,
                            FirstName = u.FirstName,                                    
                            LastName = u.LastName,
                            Email = u.Email,
                            IsActive = u.IsActive
                        })
                       .ToList();

            if (!users.Any())
                return NotFound("No users found");

            return Ok(users);
        }
    }
}
