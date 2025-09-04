using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HolidayImagesAPI.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        [JsonIgnore]
        public Category? Category { get; set; }

        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        [JsonIgnore]
        public Category? SubCategory { get; set; }

    }
}
