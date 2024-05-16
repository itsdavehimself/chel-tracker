using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Models
{
    public class Game
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public string UserTeam { get; set; } = string.Empty;

        public string OpponentTeam { get; set; } = string.Empty;

        public Difficulty Difficulty { get; set; }

        public int UserScore { get; set; }

        public int OpponentScore { get; set; }

        public int UserShots { get; set; }

        public int OpponentShots { get; set; }

        public int UserHits { get; set; }

        public int OpponentHits { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Opponent")]
        public int OpponentId { get; set; }
    }

    public enum Difficulty { Rookie, SemiPro, Pro, AllStar, Superstar }
}