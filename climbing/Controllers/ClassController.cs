using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using climbing.Data;
using climbing.Domain;
using climbing.Dtos;

namespace climbing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            var classes = await _context.Classes.ToListAsync();
            return Ok(classes);

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ClassDto>>> AddClass(ClassDto dto)
        {
            var newClass = new Class()
            {
                Name = dto.Name,
                Description = dto.Description,
                Instructor = dto.Instructor,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Capacity = dto.Capacity,
                Price = dto.Price,
                IsActive = true
            };

            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();


            var response = new ClassDto
            {
                Id = newClass.Id,
                Description = newClass.Description,
                Instructor = newClass.Instructor,
                StartTime = newClass.StartTime,
                EndTime = newClass.EndTime,
                Capacity = newClass.Capacity,
                Price = newClass.Price,
                IsActive = newClass.IsActive 

            };

            return CreatedAtAction(nameof(GetClasses), new { id = newClass.Id }, response);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ClassDto>>> UpdateClass(int id, ClassDto dto)
        {
            var existingClass = await _context.Classes.FindAsync(id);
            if (existingClass == null)
            {
                return NotFound();
            }
            existingClass.Name = dto.Name;
            existingClass.Description = dto.Description;
            existingClass.Instructor = dto.Instructor;
            existingClass.StartTime = dto.StartTime;
            existingClass.EndTime = dto.EndTime;
            existingClass.Capacity = dto.Capacity;
            existingClass.Price = dto.Price;
            existingClass.IsActive = dto.IsActive;
            await _context.SaveChangesAsync();
            return Ok(existingClass);
        }
    }
}
