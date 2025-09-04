using HolidayImagesAPI.Data;
using HolidayImagesAPI.DTOs;
using HolidayImagesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static HolidayImagesAPI.DTOs.CategoryResponseDto;

namespace HolidayImagesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_context.Categories.ToList());
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/categories
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            if (category == null)
                return BadRequest();

            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id)
                return BadRequest();

            var existingCategory = _context.Categories.Find(id);
            if (existingCategory == null)
                return NotFound();

            
            
            existingCategory.ParentId = category.ParentId;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("subcategories")]
        public IActionResult GetSubCategories([FromQuery] int parentCategoryId)
        {
            var subCategories = _context.Categories
                .Where(c => c.ParentId == parentCategoryId)
                .Select(c => new SubCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return Ok(subCategories);
        }
    }
}
