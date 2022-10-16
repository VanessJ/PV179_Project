using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaar.DAL.Models
{
    public class Reaction : BaseEntity
    {
        public string Message { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } 

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public virtual Ad Ad { get; set; }  

        public bool Accepted { get; set; }

    }
}
