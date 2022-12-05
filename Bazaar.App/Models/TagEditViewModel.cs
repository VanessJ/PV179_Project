using System.ComponentModel.DataAnnotations;

namespace Bazaar.App.Models
{
    public class TagEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string TagName { get; set; }
    }
}
