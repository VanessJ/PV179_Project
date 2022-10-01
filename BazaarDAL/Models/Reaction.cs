using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class Reaction
    {
        public string Message { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; } 

        public int AdId { get; set; }
        public virtual Ad Ad { get; set; }  

    }
}
