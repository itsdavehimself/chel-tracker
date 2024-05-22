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

        public int UserTimeOnAttack { get; set; }

        public int OpponentTimeOnAttack { get; set; }

        public float UserPassingPercentage { get; set; }

        public float OpponentPassingPercentage { get; set; }

        public int UserFaceOffWins { get; set; }

        public int OpponentFaceOffWins { get; set; }

        public int UserPenaltyMinutes { get; set; }

        public int OpponentPenaltyMinutes { get; set; }

        public float UserPowerPlayPercentage { get; set; }

        public float OpponentPowerPlayPercentage { get; set; }

        public int UserPowerPlayMinutes { get; set; }

        public int OpponentPowerPlayMinutes { get; set; }

        public int UserShortHandedGoals { get; set; }

        public int OpponentShortHandedGoals { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("Opponent")]
        public int OpponentId { get; set; }
    }

    public enum Difficulty { Rookie, SemiPro, Pro, AllStar, Superstar }
}