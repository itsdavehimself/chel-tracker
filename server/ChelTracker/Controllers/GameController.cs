using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.Game;
using ChelTracker.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChelTracker.Controllers
{
    [Route("api/game")]
    [ApiController]

    public class GameController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GameController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game.ToGameDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserIdAndOpponentId([FromQuery(Name = "user")] int userId, [FromQuery(Name = "opponent")] int opponentId)
        {
            try
            {
                var games = await _context.Games
                    .Where(g => g.UserId == userId && g.OpponentId == opponentId)
                    .ToListAsync();

                var gamesDto = games.Select(g => g.ToGameDto());

                if (!gamesDto.Any())
                {
                    return NotFound();
                }

                return Ok(gamesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameRequestDto gameDto)
        {

            if (!DateTime.TryParse(gameDto.Date, out DateTime date))
            {
                return BadRequest("Invalid date format. Please provide the date in YYYY-MM-DD format.");
            }

            var dateOnly = new DateOnly(date.Year, date.Month, date.Day);

            var gameModel = gameDto.ToGameFromCreateDto(dateOnly);
            await _context.Games.AddAsync(gameModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = gameModel.Id }, gameModel.ToGameDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameRequestDto updateDto)
        {
            var gameModel = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (gameModel == null)
            {
                return NotFound();
            }

            if (!DateTime.TryParse(updateDto.Date, out DateTime date))
            {
                return BadRequest("Invalid date format. Please provide the date in YYYY-MM-DD format.");
            }

            var dateOnly = new DateOnly(date.Year, date.Month, date.Day);

            gameModel.Date = dateOnly;
            gameModel.UserTeam = updateDto.UserTeam;
            gameModel.OpponentTeam = updateDto.OpponentTeam;
            gameModel.Difficulty = updateDto.Difficulty;
            gameModel.UserScore = updateDto.UserScore;
            gameModel.OpponentScore = updateDto.OpponentScore;
            gameModel.UserShots = updateDto.UserShots;
            gameModel.OpponentShots = updateDto.OpponentShots;
            gameModel.UserHits = updateDto.UserHits;
            gameModel.OpponentHits = updateDto.OpponentHits;
            gameModel.UserId = updateDto.UserId;
            gameModel.OpponentId = updateDto.OpponentId;
            await _context.SaveChangesAsync();

            return Ok(gameModel.ToGameDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var gameModel = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (gameModel == null)
            {
                return NotFound();
            }

            _context.Games.Remove(gameModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}