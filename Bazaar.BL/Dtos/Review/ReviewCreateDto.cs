using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Review
{
    public class ReviewCreateDto
    {
        public UserDto Reviewer { get; set; }

        public UserDto Reviewed { get; set; }

        public int Score { get; set; }

        public string? Descritption { get; set; }
    }
}
