using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [MaxLength(64)]
        public string TagName { get; set; }
        
        public virtual ICollection<AdTag> AdTag { get; set; }

    }
}
