using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class Review
    {
        public int ReviewerId { get; set; }

        public virtual User Reviewer { get; set; }

        public int ReviewedId { get; set; }

        public virtual User Reviewed {get; set;}

        [Range(1, 5)]
        public int Score { get; set; }

        public string? Descritption { get; set; } 




    }
}
