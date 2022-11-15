using Bazaar.BL.Dtos.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Image
{
    public class ImageCreateDto
    {
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;
        public AdDto Ad { get; set; } = null!;
    }
}
