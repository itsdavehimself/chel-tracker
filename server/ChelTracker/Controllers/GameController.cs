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
        public IActionResult GetById([FromRoute] int id)
        {
            var game = _context.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game.ToGameDto());
        }

        [HttpGet]
        public IActionResult GetByUserIdAndOpponentId([FromQuery(Name = "user")] int userId, [FromQuery(Name = "opponent")] int opponentId)
        {
            try
            {
                var games = _context.Games
                    .Where(g => g.UserId == userId && g.OpponentId == opponentId)
                    .ToList()
                    .Select(g => g.ToGameDto());

                if (!games.Any())
                {
                    return NotFound();
                }

                return Ok(games);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateGameRequestDto gameDto)
        {

            if (!DateTime.TryParse(gameDto.Date, out DateTime date))
            {
                return BadRequest("Invalid date format. Please provide the date in YYYY-MM-DD format.");
            }

            var dateOnly = new DateOnly(date.Year, date.Month, date.Day);

            var gameModel = gameDto.ToGameFromCreateDto(dateOnly);
            _context.Games.Add(gameModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = gameModel.Id }, gameModel.ToGameDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateGameRequestDto updateDto)
        {
            var gameModel = _context.Games.FirstOrDefault(g => g.Id == id);

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
            _context.SaveChanges();

            return Ok(gameModel.ToGameDto());
        }
    }
}