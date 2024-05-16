using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Data;
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

        [HttpGet]
        public IActionResult GetByUserId([FromRoute] int userId)
        {
            try
            {
                var opponents = _context.Opponents.Where(o => o.UserId == userId).ToList();
                if (opponents.Count == 0)
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

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var opponent = _context.Opponents.Find(id);

            if (opponent == null)
            {
                return NotFound();
            }

            return Ok(opponent);
        }
    }
}