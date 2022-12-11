using Bazaar.BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Reaction
{
    public class ReactionFilterDto : BaseFilterDto
    {
        public Guid UserId { get; set; }
    }
}
