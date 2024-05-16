using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.Game;
using ChelTracker.Models;

namespace ChelTracker.Mappers
{
    public static class GameMappers
    {
        public static GameDto ToGameDto(this Game gameModel)
        {
            return new GameDto
            {
                Id = gameModel.Id,
                Date = gameModel.Date,
                Difficulty = gameModel.Difficulty,
                UserTeam = gameModel.UserTeam,
                OpponentTeam = gameModel.OpponentTeam,
                UserScore = gameModel.UserScore,
                OpponentScore = gameModel.OpponentScore,
                UserShots = gameModel.UserShots,
                OpponentShots = gameModel.OpponentShots,
                UserHits = gameModel.UserHits,
                OpponentHits = gameModel.OpponentHits,
            };
        }
    }
}