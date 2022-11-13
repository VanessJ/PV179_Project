using Bazaar.BL.Dto.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dto.Image
{
    public class ImageCreate
    {
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;
        public AdDto Ad { get; set; } = null!;
    }
}
