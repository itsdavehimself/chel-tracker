using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.Opponent;
using ChelTracker.Models;

namespace ChelTracker.Mappers
{
    public static class OpponentMappers
    {
        public static OpponentDto ToOpponentDto(this Opponent opponentModel)
        {
            return new OpponentDto
            {
                OpponentId = opponentModel.OpponentId,
                Name = opponentModel.Name,
            };
        }

        public static Opponent ToOpponentFromCreateDto(this CreateOpponentRequestDto opponentDto)
        {
            return new Opponent
            {
                Name = opponentDto.Name,
                UserId = opponentDto.UserId
            };
        }
    }
}