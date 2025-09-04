namespace HolidayImagesAPI.DTOs
{
    public class ImageResponseDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        // İstersen hangi kategoriye bağlı olduğunu gösterebilirsin:
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }




    }
}
