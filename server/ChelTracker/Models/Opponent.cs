using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Models
{
    public class Opponent
    {
        public int OpponentId { get; set; }
        public string Name { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}