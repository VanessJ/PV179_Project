using Bazaar.BL.Dtos.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Tag
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string TagName { get; set; } = null!;

        public AdDto Ad { get; set; } = null!;
    }
}
