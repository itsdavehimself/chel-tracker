using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.Game;
using ChelTracker.Dtos.Opponent;
using Microsoft.EntityFrameworkCore;

namespace ChelTracker.Dtos.User
{
    public class UserDto
    {

        public string Id { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public List<GameDto> Games { get; set; } = new List<GameDto>();
        public List<OpponentDto> Opponents { get; set; } = new List<OpponentDto>();
    }
}