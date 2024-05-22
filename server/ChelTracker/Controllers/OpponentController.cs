using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
using ChelTracker.Dtos.Opponent;
using ChelTracker.Interfaces;
using ChelTracker.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChelTracker.Controllers
{
    [Route("api/opponent")]
    [ApiController]
    [Authorize]
    public class OpponentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IOpponentRepository _opponentRepository;

        public OpponentController(ApplicationDBContext context, IOpponentRepository opponentRepository)
        {
            _opponentRepository = opponentRepository;
            _context = context;
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var opponents = await _opponentRepository.GetAllUsersOpponentsAsync(userId);

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

        [HttpGet("user/{userId}/opponents-with-stats")]
        public async Task<IActionResult> GetOpponentsWithStats(string userId)
        {
            try
            {
                var opponentsWithStats = await _opponentRepository.GetOpponentsWithStatsAsync(userId);
                return Ok(opponentsWithStats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{opponentId:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int opponentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opponent = await _opponentRepository.GetOpponentByIdAsync(opponentId);

            if (opponent == null)
            {
                return NotFound();
            }

            return Ok(opponent.ToOpponentDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOpponentRequestDto opponentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opponentModel = opponentDto.ToOpponentFromCreateDto();
            await _opponentRepository.CreateOpponentAsync(opponentModel);
            return CreatedAtAction(nameof(GetById), new { opponentId = opponentModel.OpponentId }, opponentModel.ToOpponentDto());
        }

        [HttpPut]
        [Route("{opponentId:int}")]
        [Authorize]

        public async Task<IActionResult> Update([FromRoute] int opponentId, [FromBody] UpdateOpponentRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opponentModel = await _opponentRepository.UpdateOpponentAsync(opponentId, updateDto);

            if (opponentModel == null)
            {
                return NotFound();
            }

            return Ok(opponentModel.ToOpponentDto());
        }

        [HttpDelete]
        [Route("{opponentId:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int opponentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opponentModel = await _opponentRepository.DeleteOpponentAsync(opponentId);

            if (opponentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}