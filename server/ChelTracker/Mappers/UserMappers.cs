using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.User;
using ChelTracker.Models;

namespace ChelTracker.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Username = userModel.UserName ?? "",
                Email = userModel.Email ?? "",
                Games = userModel.Games.Select(g => g.ToGameDto()).ToList(),
                Opponents = userModel.Opponents.Select(o => o.ToOpponentDto()).ToList()
            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Email = userDto.Email,
                UserName = userDto.Username,
                PasswordHash = userDto.Password,
            };
        }
    }
}