using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        [MaxLength(64)]
        public string Title { get; set; }

        public string PathToImg { get; set; }   

        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }

    }
}
