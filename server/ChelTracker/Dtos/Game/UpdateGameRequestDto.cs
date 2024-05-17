using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Models;
using System.ComponentModel.DataAnnotations;


namespace ChelTracker.Dtos.Game
{
    public class UpdateGameRequestDto
    {
        [Required(ErrorMessage = "A date is required.")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Date must be in the format YYYY-MM-DD")]
        public string Date { get; set; } = string.Empty;

        [Required(ErrorMessage = "User team name is required")]
        [MinLength(5, ErrorMessage = "User team name must be 5 characters or more.")]
        [MaxLength(15, ErrorMessage = "User team name must be 15 characters or less.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "User team name can only contain letters or numbers.")]
        public string UserTeam { get; set; } = string.Empty;

        [Required(ErrorMessage = "Opponent team name is required")]
        [MinLength(5, ErrorMessage = "Opponent team name must be 5 characters or more.")]
        [MaxLength(15, ErrorMessage = "Opponent team name must be 15 characters or less.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Opponent team name can only contain letters or numbers.")]
        public string OpponentTeam { get; set; } = string.Empty;

        [Required(ErrorMessage = "Difficulty is required")]
        public Difficulty Difficulty { get; set; }

        public bool IsValidDifficulty()
        {
            return Enum.IsDefined(typeof(Difficulty), Difficulty);
        }

        [Required(ErrorMessage = "User score is required.")]
        [Range(0, 99, ErrorMessage = "User score must be between 0 and 99.")]
        public int UserScore { get; set; }

        [Required(ErrorMessage = "Opponent score is required.")]
        [Range(0, 99, ErrorMessage = "Opponent score must be between 0 and 99.")]
        public int OpponentScore { get; set; }

        [Required(ErrorMessage = "User shots is required.")]
        [Range(0, 99, ErrorMessage = "User shots must be between 0 and 99.")]
        public int UserShots { get; set; }

        [Required(ErrorMessage = "Opponent shots is required.")]
        [Range(0, 99, ErrorMessage = "Opponent shots must be between 0 and 99.")]
        public int OpponentShots { get; set; }

        [Required(ErrorMessage = "User hits is required.")]
        [Range(0, 99, ErrorMessage = "User hits must be between 0 and 99.")]
        public int UserHits { get; set; }

        [Required(ErrorMessage = "Opponent hits is required.")]
        [Range(0, 99, ErrorMessage = "Opponent hits must be between 0 and 99.")]
        public int OpponentHits { get; set; }
    }
}