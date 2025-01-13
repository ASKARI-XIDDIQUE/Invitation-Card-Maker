using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.Models
{
    public class Category:BaseClass
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Template> Template {  get; set; }
    }
}
