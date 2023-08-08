
using System.ComponentModel.DataAnnotations;

namespace MyPrecticesCatSabcat.Models
{
    public class test
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name"), Required(ErrorMessage = "please Enter Category Name")]
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
