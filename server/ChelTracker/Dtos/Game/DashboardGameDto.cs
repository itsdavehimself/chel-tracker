using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Dtos.Game
{
    public class DashboardGameDto
    {
        public int UserScore { get; set; }
        public int OpponentScore { get; set; }
        public DateOnly Date { get; set; }

    }
}