using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }
        [Required(ErrorMessage = "Display Order is required")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
