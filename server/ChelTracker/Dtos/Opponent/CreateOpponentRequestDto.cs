using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Dtos.Opponent
{
    public class CreateOpponentRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }


    }
}