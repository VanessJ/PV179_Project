using Bazaar.BL.Dto.Ad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dto.Reaction
{
    public class ReactionDto
    {
        public int Id { get; set; }
        public string? Message { get; set; }

        public UserDto User { get; set; } = null!;

        public AdDto Ad { get; set; } = null!;

        public bool Accepted { get; set; }
    }
}
