using System.ComponentModel.DataAnnotations;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.App.Models
{
    public class TagInsertViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string TagName { get; set; }
    }
}
