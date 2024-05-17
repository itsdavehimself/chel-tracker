using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Dtos.Opponent
{
    public class CreateOpponentRequestDto
    {
        [Required(ErrorMessage = "An opponent name is required")]
        [MinLength(5, ErrorMessage = "Opponent's name must be 5 characters or more.")]
        [MaxLength(15, ErrorMessage = "Opponent's name must be 15 characters or less.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Opponent's name can only contain letters or numbers.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A userID is required.")]
        public string UserId { get; set; } = string.Empty;


    }
}