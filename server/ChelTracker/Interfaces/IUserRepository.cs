using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.User;
using ChelTracker.Models;

namespace ChelTracker.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(string userId);

        Task<User> CreateUserAsync(User userModel);

        Task<User?> UpdateUserAsync(string userId, UpdateUserRequestDto updateDto);

        Task<User?> DeleteUserAsync(string userId);

        Task<bool> UserExists(string userId);

    }
}