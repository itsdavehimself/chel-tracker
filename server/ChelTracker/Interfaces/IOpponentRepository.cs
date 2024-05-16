using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.Opponent;
using ChelTracker.Models;

namespace ChelTracker.Interfaces
{
    public interface IOpponentRepository
    {
        Task<List<Opponent>> GetAllUsersOpponentsAsync(int userId);

        Task<Opponent?> GetOpponentByIdAsync(int opponentId);

        Task<Opponent> CreateOpponentAsync(Opponent opponentModel);

        Task<Opponent?> UpdateOpponentAsync(int opponentId, UpdateOpponentRequestDto opponentDto);

        Task<Opponent?> DeleteOpponentAsync(int opponentId);
    }
}