using System.ComponentModel.DataAnnotations;

namespace Bazaar.DAL.Models
{
    public class Tag : BaseEntity
    {
        [MaxLength(64)]
        public string TagName { get; set; }
        
        public virtual ICollection<Ad> Ads { get; set; }

    }
}
