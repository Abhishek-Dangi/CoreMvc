using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Country_State_District_City_Relation.Models
{
    [Table("tbl_State")]
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "enter title"), MinLength(2)]
        public string Title { get; set; }


        //foreignkey of country 
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        //mapping childs
        public ICollection<District> District { get; set; }

    }
}
