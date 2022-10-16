using System.ComponentModel.DataAnnotations;

namespace Bazaar.DAL.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
