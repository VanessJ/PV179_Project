
namespace Bazaar.DAL.Models
{
    public class AdTag
    {
        public int AdId { get; set; }
        public virtual Ad Ad { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}