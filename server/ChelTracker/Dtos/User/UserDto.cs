using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.Game;
using ChelTracker.Dtos.Opponent;

namespace ChelTracker.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<GameDto> Games { get; set; } = new List<GameDto>();

        public List<OpponentDto> Opponents { get; set; } = new List<OpponentDto>();

    }
}