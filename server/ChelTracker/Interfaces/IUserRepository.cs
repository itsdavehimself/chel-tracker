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
        Task<User?> GetUserByIdAsync(int userId);

        Task<User> CreateUserAsync(User userModel);

        Task<User?> UpdateUserAsync(int userId, UpdateUserRequestDto updateDto);

        Task<User?> DeleteUserAsync(int userId);

        Task<bool> UserExists(int userId);

    }
}