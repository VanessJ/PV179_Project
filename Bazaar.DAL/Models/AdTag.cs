using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaar.DAL.Models
{
    public class AdTag : BaseEntity
    {
        public Guid TagId { get; set; }
        
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }

        public Guid AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public virtual Ad Ad { get; set; }
    }
}
