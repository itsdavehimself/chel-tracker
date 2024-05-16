using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.Opponent;
using ChelTracker.Interfaces;
using ChelTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ChelTracker.Repositories
{
    public class OpponentRepository : IOpponentRepository
    {

        private readonly ApplicationDBContext _context;

        public OpponentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Opponent>> GetAllUsersOpponentsAsync(int userId)
        {
            return await _context.Opponents.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<Opponent?> GetOpponentByIdAsync(int opponentId)
        {
            return await _context.Opponents.FirstOrDefaultAsync(o => o.OpponentId == opponentId);
        }

        public async Task<Opponent> CreateOpponentAsync(Opponent opponentModel)
        {
            await _context.Opponents.AddAsync(opponentModel);
            await _context.SaveChangesAsync();
            return opponentModel;
        }

        public async Task<Opponent?> UpdateOpponentAsync(int opponentId, UpdateOpponentRequestDto updateDto)
        {
            var existingOpponent = await _context.Opponents.FirstOrDefaultAsync(o => o.OpponentId == opponentId);

            if (existingOpponent == null)
            {
                return null;
            }

            existingOpponent.Name = updateDto.Name;
            await _context.SaveChangesAsync();
            return existingOpponent;
        }

        public async Task<Opponent?> DeleteOpponentAsync(int opponentId)
        {
            var existingOpponent = await _context.Opponents.FirstOrDefaultAsync(o => o.OpponentId == opponentId);

            if (existingOpponent == null)
            {
                return null;
            }

            _context.Opponents.Remove(existingOpponent);
            await _context.SaveChangesAsync();
            return existingOpponent;
        }
    }
}