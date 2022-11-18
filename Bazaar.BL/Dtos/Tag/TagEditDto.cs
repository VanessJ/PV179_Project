using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Tag
{
    public class TagEditDto
    {
        public Guid Id { get; set; }
        public string TagName { get; set; } = null!;
    }
}
