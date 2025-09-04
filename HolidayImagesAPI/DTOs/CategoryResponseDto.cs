namespace HolidayImagesAPI.DTOs
{
    public class CategoryResponseDto
    {
        
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; } = new();

        // Kategoriye bağlı resimleri göstermek için:
        public List<ImageResponseDto> Images { get; set; } = new();

        public class SubCategoryDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }
}
