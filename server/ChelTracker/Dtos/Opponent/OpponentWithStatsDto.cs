using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.Game;


namespace ChelTracker.Dtos.Opponent
{
    public class OpponentWithStats
    {
        public OpponentDto Opponent { get; set; } = new OpponentDto();
        public List<DashboardGameDto> Games { get; set; } = new List<DashboardGameDto>();
    }
}