using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class AdTag
    {
        public int AdId { get; set; }
        public virtual Ad Ad { get; set; }  

        public int TagId { get; set; }   

        public virtual Tag Tag { get; set; }    
    }
}
