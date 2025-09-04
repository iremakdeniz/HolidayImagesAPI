using Microsoft.AspNetCore.Mvc;

namespace HolidayImagesAPI.DTOs
{
    public class UploadImageRequestcs
    {
       
            [FromForm]

            public IFormFile File { get; set; }

            [FromForm]

            public int SubCategoryId { get; set; }

        

    }
}
