
namespace Bazaar.DAL.Models
{
    public class AdTag
    {
        public Guid AdId { get; set; }
        public virtual Ad Ad { get; set; }

        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}