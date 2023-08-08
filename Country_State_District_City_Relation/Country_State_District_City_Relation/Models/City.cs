using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Country_State_District_City_Relation.Models
{
    [Table("tbl_City")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "enter title"), MinLength(2)]
        public string Title { get; set; }

        //foreignkey of District
        [ForeignKey("CountryId"), NotMapped]
        public int CountryId { get; set; }

        [ForeignKey("StateId"), NotMapped]
        public int StateId { get; set; }

        [ForeignKey("DistrictId")]
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
