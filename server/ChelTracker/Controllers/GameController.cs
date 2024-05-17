using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.Game;
using ChelTracker.Helpers;
using ChelTracker.Interfaces;
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

        private readonly IGameRepository _gameRepository;

        private readonly IUserRepository _userRepository;

        private readonly IOpponentRepository _opponentRepository;

        public GameController(ApplicationDBContext context, IGameRepository gameRepository, IUserRepository userRepository, IOpponentRepository opponentRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _opponentRepository = opponentRepository;
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = await _gameRepository.GetGameByIdAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game.ToGameDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserIdAndOpponentId([FromQuery] GameQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var games = await _gameRepository.GetGameByBothUsersAsync(query.UserId, query.OpponentId);

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
        [Route("{userId}")]
        public async Task<IActionResult> Create([FromRoute] string userId, int opponentId, [FromBody] CreateGameRequestDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userRepository.UserExists(userId) && !await _opponentRepository.OpponentExists(opponentId))
            {
                return BadRequest("User or Opponent does not exist!");
            }

            if (!DateTime.TryParse(gameDto.Date, out DateTime date))
            {
                return BadRequest("Invalid date format. Please provide the date in YYYY-MM-DD format.");
            }

            var dateOnly = new DateOnly(date.Year, date.Month, date.Day);

            var gameModel = gameDto.ToGameFromCreateDto(dateOnly, userId, opponentId);
            await _gameRepository.CreateGameAsync(gameModel);
            return CreatedAtAction(nameof(GetById), new { id = gameModel.Id }, gameModel.ToGameDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameModel = await _gameRepository.UpdateGameAsync(id, updateDto);

            if (gameModel == null)
            {
                return NotFound();
            }

            return Ok(gameModel.ToGameDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameModel = await _gameRepository.DeleteGameAsync(id);

            if (gameModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}