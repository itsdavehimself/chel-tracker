using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.User;
using ChelTracker.Interfaces;
using ChelTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ChelTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                            .Include(u => u.Games)
                            .Include(u => u.Opponents)
                            .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User> CreateUserAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> UpdateUserAsync(int userId, UpdateUserRequestDto updateDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Email = updateDto.Email;
            existingUser.Username = updateDto.Username;
            existingUser.Password = updateDto.Password;
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User?> DeleteUserAsync(int userId)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (existingUser == null)
            {
                return null;
            }

            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;

        }
    }
}