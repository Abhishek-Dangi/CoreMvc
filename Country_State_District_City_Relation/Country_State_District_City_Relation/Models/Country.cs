using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Country_State_District_City_Relation.Models
{
    [Table("tbl_Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "enter title"), MinLength(2)]
        public string Title { get; set; }

        public int DisplayOrder { get;set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        //mapping childs
        public ICollection<State> State { get; set; } 
    }
}
