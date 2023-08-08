using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Country_State_District_City_Relation.Models
{
    [Table("tbl_District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "enter title"), MinLength(2)]
        public string Title { get; set; }
        //foreignkey of state 
        [ForeignKey("CountryId"),NotMapped]
        public int CountryId { get; set; }



        [ForeignKey("StateId")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        //mapping childs
        public ICollection<City> City { get;set; }

    }
}
