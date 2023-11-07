using Lib.Models.Product;
using Lib.Models.Service;
using Lib.Models.User;
using Lib.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SurfboardController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly UserManager<Customer> _userManager; //Understand | move to Rent and Store project?
        private readonly UserManager<Guest> _guestManager; //Needed?

        public SurfboardController(ProductContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region [Post] AddSurfboard *
        #endregion

        #region [Put] EditSurfboard *
        #endregion

        #region [Delete] DeleteSurfboard * 
        #endregion

        #region [Get] GetAllSurfboards
        // Route: api/surfboards
        [HttpGet("surfboards")]
        public async Task<ActionResult<IEnumerable<Surfboard>>> GetAllSurfboards()
        {
            if (_context.Surfboard == null)
            {
                return NotFound();
            }

            IEnumerable<Surfboard> surfboards = await _context.Surfboard.ToListAsync();

            var jsonSerialized = JsonSerializer.Serialize(surfboards);
            return Ok(jsonSerialized);
        }
        #endregion

        #region [Post] Rent (Surfboard)
        // Route: api/rent/id
        [HttpPost("rent/{id}")]
        public async Task<ActionResult<Rental>> Rent([FromQuery] int id, [FromBody] Rental rental) //Understand
        {
            if (_context.Rental == null)
            {
                return Problem("Entity set 'productcontext.Rental' is null");
            }

            bool rentalIsAvailable = await _context.Rental.AnyAsync(rental => rental.SurfboardId != id);

            if (!rentalIsAvailable)
            {
                return BadRequest("Surfboard is already rented out");
            }
            else if (User != null)
            {
                _context.Rental.Add(rental);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRental", new { id = rental.Id }, rental); //??
            }
            else if (rental.GuestEmail != null && rental.Surbroad.Price <= 200)
            {
                //_context.Rental.Add(rental);
                //await _context.SaveChangesAsync();

                return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
            }
            else
            {
                return BadRequest("Guest or Customer login is required");
            }
        }
        #endregion

        #region [Put] EditRental *
        #endregion

        #region [Delete] DeleteRental
        // Route: api/rental/delete/id
        [HttpDelete("/rental/delete/{id}")]
        public async Task<ActionResult<Rental>> DeleteRental([FromQuery] int id)
        {
            if (_context.Rental == null)
            {
                return Ok("No surfboard is rented out at the moment");
            }
            else
            {
                var rental = await _context.Rental.FindAsync(id);
                _context.Rental.Remove(rental);
                await _context.SaveChangesAsync();

                return Ok();
            }

        }
        #endregion

        #region [Get] GetAllRentals
        // Route: api/rentals
        [HttpGet("rentals")]
        public async Task<ActionResult<Rental>> GetAllRentals()
        {
            if (_context.Rental == null)
            {
                return Ok("No surfboard is rented out at the moment");
            }

            if (User.IsInRole("Employee"))
            {
                IEnumerable<Rental> rentals = await _context.Rental.ToListAsync();
                var jsonSerialize = JsonSerializer.Serialize(rentals);
                return Ok(jsonSerialize);
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);
                string userId = user.Id;

                IEnumerable<Rental> rentals = await _context.Rental
                    .Include(obj => obj.Surbroad)
                    .Include(obj => obj.Customer)
                    .Where(rental => rental.CustomerId == userId)
                    .ToListAsync();

                var jsonSerialize = JsonSerializer.Serialize(rentals);

                return Ok(jsonSerialize);
            }
        }
        #endregion
    }
}
