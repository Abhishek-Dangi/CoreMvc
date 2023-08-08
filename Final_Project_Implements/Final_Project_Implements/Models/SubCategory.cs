using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace Final_Project_Implements.Models
{
    [Table("tbl_SubCategory")]
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="enter title"), MinLength(2)]
        public string Title { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Post> Post { get; set; }
    }
}
