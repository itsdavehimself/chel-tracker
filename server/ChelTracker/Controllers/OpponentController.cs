using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.Opponent;
using ChelTracker.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChelTracker.Controllers
{
    [Route("api/opponent")]
    [ApiController]
    public class OpponentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OpponentController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            try
            {
                var opponents = await _context.Opponents.Where(o => o.UserId == userId).ToListAsync();

                var opponentsDto = opponents.Select(o => o.ToOpponentDto());

                if (!opponentsDto.Any())
                {
                    return NotFound();
                }

                return Ok(opponentsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("{opponentId}")]
        public async Task<IActionResult> GetById([FromRoute] int opponentId)
        {
            var opponent = await _context.Opponents.FindAsync(opponentId);

            if (opponent == null)
            {
                return NotFound();
            }

            return Ok(opponent.ToOpponentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOpponentRequestDto opponentDto)
        {
            var opponentModel = opponentDto.ToOpponentFromCreateDto();
            await _context.Opponents.AddAsync(opponentModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { opponentId = opponentModel.OpponentId }, opponentModel.ToOpponentDto());
        }

        [HttpPut]
        [Route("{opponentId}")]

        public async Task<IActionResult> Update([FromRoute] int opponentId, [FromBody] UpdateOpponentRequestDto updateDto)
        {
            var opponentModel = await _context.Opponents.FirstOrDefaultAsync(o => o.OpponentId == opponentId);

            if (opponentModel == null)
            {
                return NotFound();
            }

            opponentModel.Name = updateDto.Name;
            await _context.SaveChangesAsync();

            return Ok(opponentModel.ToOpponentDto());
        }

        [HttpDelete]
        [Route("{opponentId}")]
        public async Task<IActionResult> Delete([FromRoute] int opponentId)
        {
            var opponentModel = await _context.Opponents.FirstOrDefaultAsync(o => o.OpponentId == opponentId);

            if (opponentModel == null)
            {
                return NotFound();
            }

            _context.Opponents.Remove(opponentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}