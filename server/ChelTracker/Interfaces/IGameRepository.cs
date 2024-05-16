using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Dtos.Game;
using ChelTracker.Models;

namespace ChelTracker.Interfaces
{
    public interface IGameRepository
    {
        Task<Game?> GetGameByIdAsync(int id);

        Task<List<Game>> GetGameByBothUsersAsync(int userId, int opponentId);

        Task<Game> CreateGameAsync(Game gameModel);

        Task<Game?> UpdateGameAsync(int id, UpdateGameRequestDto updateDto);

        Task<Game?> DeleteGameAsync(int id);
    }
}