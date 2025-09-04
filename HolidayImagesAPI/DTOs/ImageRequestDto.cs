namespace HolidayImagesAPI.DTOs
{
    public class ImageRequestDto
    {
        public string Url { get; set; } = string.Empty;
        public int CategoryId { get; set; } // Resim hangi kategoriye bağlı

        public int SubCategoryId { get; set; }
    }
}
