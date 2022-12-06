using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.AdTag
{
    public class AdTagDto
    {
        public TagDto Tag{ get; set; }
        public AdDto Ad { get; set; }
        public Guid TagId { get; set; }
        public Guid AdId { get; set; }
    }
}
