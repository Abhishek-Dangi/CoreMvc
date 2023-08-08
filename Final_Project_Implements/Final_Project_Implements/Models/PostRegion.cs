using Final_Project_Implements.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Implements.Areas.Admin.Models
{
    public class PostRegion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Post Title"), Required(ErrorMessage ="Please Enter Title")]
        [MinLength(2)]
        public string Title { get; set; }

        [Required(ErrorMessage ="Please Enter Discription")]
        [MinLength(2)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<Post> Post { get; set; }

    }
}
