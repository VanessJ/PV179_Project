using Bazaar.BL.Dto.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dto.Tag
{
    public class TagCreateDto
    {
        public string TagName { get; set; } = null!;

        public AdDto Ad { get; set; } = null!;
    }
}
