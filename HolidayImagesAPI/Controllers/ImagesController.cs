using HolidayImagesAPI.Data;
using HolidayImagesAPI.DTOs;
using HolidayImagesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HolidayImagesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ImagesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequestcs request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("Bir dosya seçilmedi.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.File.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }
            
     
            var subCategory = await _context.Categories.FindAsync(request.SubCategoryId);
            if (subCategory == null)
                return BadRequest("Geçersiz alt kategori.");

            if (subCategory.ParentId == null)
                return BadRequest("Bu kategori bir alt kategori değil.");

            // Resim kaydı
            var image = new Images
            {
                
                ImageUrl = "/images/" + fileName,
                SubCategoryId = request.SubCategoryId,
                CategoryId = subCategory.ParentId.Value // üst kategori backend’de set ediliyor
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return Ok(new { image.Id ,image.ImageUrl });
        }

        [HttpPost("by-subcategory")]
        public async Task<IActionResult> GetImagesBySubCategory([FromBody] ImageRequestDto request)
        {
            var images = await _context.Images
                .Where(i => i.SubCategoryId == request.SubCategoryId)
                .Select(i => new ImageResponseDto
                {
                    Id = i.Id,
                    Url = i.ImageUrl,
                    CategoryId = i.SubCategoryId
                })
                .ToListAsync();

            if (images == null || !images.Any())
                return NotFound("Bu alt kategoriye ait resim bulunamadı.");

            return Ok(images);
        }
    }
}
