using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.Models
{
    public class Template : BaseClass
    {
        public string ImagePath { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
      
        public string Description { get; set; }
       
        public string Content { get; set; }
      
        public string? TitleStyles { get; set; }
        public string? ContentStyles { get; set; }
        public string? DescriptionStyles { get; set; }
      

        
        public ICollection<UserTemplate> UserTemplate { get; set; }
       

    }
}
