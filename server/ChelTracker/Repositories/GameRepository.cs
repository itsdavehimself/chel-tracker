using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.Game;
using ChelTracker.Interfaces;
using ChelTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ChelTracker.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDBContext _context;

        public GameRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Game?> GetGameByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<List<Game>> GetGameByBothUsersAsync(string userId, int opponentId)
        {
            return await _context.Games.Where(g => g.UserId == userId && g.OpponentId == opponentId).ToListAsync();
        }

        public async Task<Game> CreateGameAsync(Game gameModel)
        {
            await _context.Games.AddAsync(gameModel);
            await _context.SaveChangesAsync();
            return gameModel;
        }

        public async Task<Game?> UpdateGameAsync(int id, UpdateGameRequestDto updateDto)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (existingGame == null)
            {
                return null;
            }

            if (!DateTime.TryParse(updateDto.Date, out DateTime date))
            {
                throw new ArgumentException("Invalid date format. Date must be in the format YYYY-MM-DD.");
            }

            var dateOnly = new DateOnly(date.Year, date.Month, date.Day);

            existingGame.Date = dateOnly;
            existingGame.UserTeam = updateDto.UserTeam;
            existingGame.OpponentTeam = updateDto.OpponentTeam;
            existingGame.Difficulty = updateDto.Difficulty;
            existingGame.UserScore = updateDto.UserScore;
            existingGame.OpponentScore = updateDto.OpponentScore;
            existingGame.UserShots = updateDto.UserShots;
            existingGame.OpponentShots = updateDto.OpponentShots;
            existingGame.UserHits = updateDto.UserHits;
            existingGame.OpponentHits = updateDto.OpponentHits;

            await _context.SaveChangesAsync();

            return existingGame;
        }

        public async Task<Game?> DeleteGameAsync(int id)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (existingGame == null)
            {
                return null;
            }

            _context.Games.Remove(existingGame);
            await _context.SaveChangesAsync();
            return existingGame;
        }
    }
}