using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.Opponent;
using ChelTracker.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetByUserId([FromRoute] int userId)
        {
            try
            {
                var opponents = _context.Opponents.Where(o => o.UserId == userId).ToList().Select(o => o.ToOpponentDto());
                if (!opponents.Any())
                {
                    return NotFound();
                }

                return Ok(opponents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("{opponentId}")]
        public IActionResult GetById([FromRoute] int opponentId)
        {
            var opponent = _context.Opponents.Find(opponentId);

            if (opponent == null)
            {
                return NotFound();
            }

            return Ok(opponent.ToOpponentDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOpponentRequestDto opponentDto)
        {
            var opponentModel = opponentDto.ToOpponentFromCreateDto();
            _context.Opponents.Add(opponentModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { opponentId = opponentModel.OpponentId }, opponentModel.ToOpponentDto());
        }
    }
}