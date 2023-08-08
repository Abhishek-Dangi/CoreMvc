using Final_Project_Implements.Areas.Admin.Models;
using Final_Project_Implements.Enum;
using Final_Project_Implements.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Implements.Models
{
    [Table("tbl_Posts")]
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Level 1 (1 to Many)

        [ForeignKey("RegionId"), Display(Name = "Region"), Required(ErrorMessage = "Please select the Region")]
        public int RegionId { get; set; }
        public virtual PostRegion PostRegion { get; set; }

        [NotMapped, Display(Name = "Category"), Required(ErrorMessage = "Please select the Category")]
        public int CategoryId { get; set; }

        //Level 1 (1 to Many)
        [ForeignKey("SubCategoryId"), Display(Name = "Sub Category"), Required(ErrorMessage = "Please select the Sub Category")]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        //Level 1 (1 to Many)

        [ForeignKey("TagId"), Display(Name = "Tag")]
        public int? TagId { get; set; }
        public virtual Tag Tag { get; set; }

        //Enum Levels
        [EnumDataType(typeof(MediaTypeEnum))]
        [Required(ErrorMessage = "Please select the Media Type")]
        [Display(Name = "Media Type")]
        public MediaTypeEnum MediaTypeEnum { get; set; }

        ////Level 1 (1 to Many)
        //[Required(ErrorMessage = "Please select the Status")]
        //[Display(Name = "Status")] public int StatusId { get; set; }
        //[ForeignKey("StatusId")]
        //public virtual Status Status { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255, ErrorMessage = "Title should not be single alphabets and not more than 200 words...!", MinimumLength = 2)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        [Column(TypeName = "nvarchar(4000)")]
        [StringLength(4000, ErrorMessage = "Description should not be single alphabets and not more than 200 words...!", MinimumLength = 2)]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [DataType(DataType.MultilineText)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Content { get; set; }


        //Document File 
        //[Required(ErrorMessage = "Upload only.doc, .docx and .pdf file.")]
        [NotMapped, Display(Name = "Image File"), DataType(DataType.Upload)]
        public IFormFile? ImageSrc { get; set; }

        [Display(Name = "Image File")]
        public string? ImageUrl { get; set; }


        //[Display(Name = "Dated")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        //public DateTime Timestamp { get; set; } = DateTime.Now;
        //[Display(Name = "Likes")] public int Likes { get; set; } = 0;
        //[Display(Name = "Active")] public bool IsActive { get; set; } = true;


        //public ICollection<LibraryAccession> LibraryAccession { get; set; } //Level 1 (1 to Many)

    }
}
