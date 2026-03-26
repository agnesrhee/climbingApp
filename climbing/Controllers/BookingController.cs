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
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _context.Bookings.ToArrayAsync();
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<BookingDto>>> AddBooking(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                UserId = dto.UserId,
                ClassId = dto.ClassId
            };

            if (_context.Users.Find(booking.UserId) == null)
            {
                return BadRequest("User not found");
            }

            if (_context.Classes.Find(booking.ClassId) == null)
            {
                return BadRequest("Class not found");
            }

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            var response = new BookingDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                ClassId = booking.ClassId,
                BookedAt = DateTime.Now,
                Status = booking.Status
            };
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<BookingDto>>> UpdateBooking(int id, BookingDto dto)
        {
            var existingBooking = await _context.Bookings.FindAsync(id);
            if (existingBooking == null)
            {
                return NotFound();
            }
            existingBooking.Status = dto.Status;
            await _context.SaveChangesAsync();
            var response = new BookingDto
            {
                Id = existingBooking.Id,
                UserId = existingBooking.UserId,
                ClassId = existingBooking.ClassId,
                BookedAt = existingBooking.BookedAt,
                Status = existingBooking.Status
            };
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> CancelBooking(int id)
        {
            var existingBooking = await _context.Bookings.FindAsync(id);
            if (existingBooking == null)
            {
                return NotFound();
            }
            _context.Bookings.Remove(existingBooking);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}