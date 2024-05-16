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

        public static Game ToGameFromCreateDto(this CreateGameRequestDto gameDto, DateOnly date)
        {
            return new Game
            {
                Date = date,
                Difficulty = gameDto.Difficulty,
                UserTeam = gameDto.UserTeam,
                OpponentTeam = gameDto.OpponentTeam,
                UserScore = gameDto.UserScore,
                OpponentScore = gameDto.OpponentScore,
                UserShots = gameDto.UserShots,
                OpponentShots = gameDto.OpponentShots,
                UserHits = gameDto.UserHits,
                OpponentHits = gameDto.OpponentHits,
                UserId = gameDto.UserId,
                OpponentId = gameDto.OpponentId,
            };
        }
    }
}