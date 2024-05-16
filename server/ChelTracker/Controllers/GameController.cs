using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
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

            return Ok(game);
        }

        [HttpGet]
        public IActionResult GetByUserIdAndOpponentId([FromQuery(Name = "user")] int userId, [FromQuery(Name = "opponent")] int opponentId)
        {
            try
            {
                var games = _context.Games
                    .Where(g => g.UserId == userId && g.OpponentId == opponentId)
                    .ToList();

                if (games.Count == 0)
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
    }
}