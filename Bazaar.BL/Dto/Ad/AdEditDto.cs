using Bazaar.BL.Dto.Image;
using Bazaar.BL.Dto.Reaction;
using Bazaar.BL.Dto.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dto.Ad
{
    public class AdEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsValid { get; set; }
        public int Price { get; set; }
        public UserDto Creator { get; set; } = null!;

        public ICollection<ImageDto> Images { get; set; }

        public ICollection<TagDto> Tags { get; set; }
    }
}
