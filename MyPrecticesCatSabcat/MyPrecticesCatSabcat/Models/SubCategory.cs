using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPrecticesCatSabcat.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "SubCategory Name"), Required(ErrorMessage = "please Enter Category Name")]
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
