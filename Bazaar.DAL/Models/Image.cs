using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaar.DAL.Models
{
    public class Image : BaseEntity
    {
        [MaxLength(255)]
        public string Title { get; set; }

        public string Url { get; set; }   

        public Guid AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public virtual Ad Ad { get; set; }

    }
}
