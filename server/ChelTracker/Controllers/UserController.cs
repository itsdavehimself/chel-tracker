using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.User;
using ChelTracker.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ChelTracker.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users
                            .Include(u => u.Games)
                            .Include(u => u.Opponents)
                            .FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{userId}")]
        public IActionResult Update([FromRoute] int userId, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (userModel == null)
            {
                return NotFound();
            }

            userModel.Email = updateDto.Email;
            userModel.Username = updateDto.Username;
            userModel.Password = updateDto.Password;
            _context.SaveChanges();

            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult Delete([FromRoute] int userId)
        {
            var userModel = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (userModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}