using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace HolidayImagesAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur")]
      
        public string Name { get; set; } = string.Empty;

      

        // Self-referencing foreign key
        public int? ParentId { get; set; } 

        // Navigation properties
        [ForeignKey("ParentId")]
        [JsonIgnore] // JSON serializasyonunda ignore et
        public Category? ParentCategory { get; set; }

        [JsonIgnore]
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        [JsonIgnore]
        public ICollection<Images> Images { get; set; } = new List<Images>();
    }
}
