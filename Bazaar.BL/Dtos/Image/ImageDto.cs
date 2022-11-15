using Bazaar.BL.Dtos.Ad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Image
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Url { get; set; } = null!;
        public AdDto Ad { get; set; } = null!;
    }
}
