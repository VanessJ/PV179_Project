using System.ComponentModel.DataAnnotations;

namespace Bazaar.App.Models
{
    public class TagCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string TagName { get; set; }
    }
}
