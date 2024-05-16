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
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _context.Users
                            .Include(u => u.Games)
                            .Include(u => u.Opponents)
                            .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (userModel == null)
            {
                return NotFound();
            }

            userModel.Email = updateDto.Email;
            userModel.Username = updateDto.Username;
            userModel.Password = updateDto.Password;
            await _context.SaveChangesAsync();

            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] int userId)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (userModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}