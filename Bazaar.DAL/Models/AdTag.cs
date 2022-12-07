using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.DAL.Models
{
    public class AdTag
    {
        public Guid TagId { get; set; }
        
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }

        public Guid AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public virtual Ad Ad { get; set; }
    }
}
