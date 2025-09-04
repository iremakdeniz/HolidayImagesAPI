namespace HolidayImagesAPI.DTOs
{
    public class SubCategoryRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
    }




}
