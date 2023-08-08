using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Implements.Models
{
    [Table("tbl_Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "enter title"), MinLength(2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<SubCategory> SubCategoryName { get; set; }
    }
}
