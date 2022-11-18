using Bazaar.BL.Dtos.Ad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Reaction
{
    public class ReactionCreateDto
    {
        public string? Message { get; set; }

        public Guid UserId { get; set; }

        public Guid AdId { get; set; } 

    }
}
