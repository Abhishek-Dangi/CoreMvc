using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Implements.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        public virtual Tag Parent { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText), Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Tag>? Parents { get; set; }
        public ICollection<Post>? Post { get; set; }
    }
}
