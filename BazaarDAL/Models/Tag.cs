using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        public string TagName { get; set; }
        
        public virtual ICollection<AdTag> AdTag { get; set; }

    }
}
