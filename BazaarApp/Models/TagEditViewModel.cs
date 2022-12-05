using System.ComponentModel.DataAnnotations;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.App.Models
{
    public class TagEditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string TagName { get; set; }
    }
}
