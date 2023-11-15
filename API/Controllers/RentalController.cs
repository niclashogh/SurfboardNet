using API.Data;
using Lib.Models.Obtain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RentalController : ControllerBase, IController<Rental>
    {
        #region Dependency Injections
        private readonly ProductContext productContext;

        public RentalController(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        #endregion

        #region [Post] AddAsync **Checkout CreatedAtAction
        // Route: api/rent/id
        [HttpPost("rent/{id}")]
        public async Task<ActionResult<Rental>> AddAsync([FromBody] Rental rental)
        {
            if (productContext.Surfboard == null)
            {
                return NotFound("Due to the automatic dataseed of Surfboard items, there is an error loading or initializing the items");
            }

            bool rentalIsAvailable = await productContext.Rental.AnyAsync(obj => obj.SurfboardId != rental.Id);

            if (!rentalIsAvailable)
            {
                return BadRequest("Surfboard is already rented out");
            }
            else if (User != null)
            {
                productContext.Rental.Add(rental);
                await productContext.SaveChangesAsync();

                return CreatedAtAction("GetRental", new { Id = rental.Id }, rental); //??
            }
            else if (rental.GuestEmail != null && rental.Surbroad.Price <= 200)
            {
                productContext.Rental.Add(rental);
                await productContext.SaveChangesAsync();

                return CreatedAtAction("GetRental", new { Id = rental.Id }, rental); //??
            }
            else
            {
                return BadRequest("Guest or Customer login is required");
            }
        }
        #endregion

        #region [Put] EditAsync
        // Route: api/rental/edit/id
        [HttpPut("rental/edit/{id}"), Authorize]
        public async Task<ActionResult<Rental>> EditAsync([Bind] Rental rental)
        {
            return BadRequest("You are not allowed to edit your rentals, this is a professional store, not your grandma's market stall");
        }
        #endregion

        #region [Delete] DeleteAsync
        // Route: api/rental/delete/id
        [HttpDelete("/rental/delete/{id}"), Authorize]
        public async Task<ActionResult<Rental>> DeleteAsync([FromQuery] int id)
        {
            if (productContext.Rental == null)
            {
                return Ok("No surfboard is rented out at the moment");
            }
            else if (User != null)
            {
                var rental = await productContext.Rental.FindAsync(id);
                productContext.Rental.Remove(rental);
                await productContext.SaveChangesAsync();

                return Ok();
            }
            else // if user is logged in as Guest
            {
                return BadRequest("This current item is rented out to a Guest, the options to confirm and cancel this rental is provided in the email we send you");
            }

        }
        #endregion

        #region [Get] GetAllAsync
        // Route: api/rentals
        [HttpGet("rentals"), Authorize]
        public async Task<ActionResult<IEnumerable<Rental>>> GetAllAsync()
        {
            if (productContext.Rental == null)
            {
                return Ok("No surfboard is rented out at the moment");
            }

            if (User.IsInRole("Employee"))
            {
                IEnumerable<Rental> rentals = await productContext.Rental.ToListAsync();
                var jsonSerialize = JsonSerializer.Serialize(rentals);
                return Ok(jsonSerialize);
            }
            else if (User != null)
            {
                IEnumerable<Rental> rentals = await productContext.Rental
                    .Include(obj => obj.Surbroad)
                    .Include(obj => obj.Customer)
                    .Where(rental => rental.CustomerId == User.FindFirstValue("Id"))
                    .ToListAsync();

                var jsonSerialize = JsonSerializer.Serialize(rentals);

                return Ok(jsonSerialize);
            }
            else // If User is not logged in
            {
                return BadRequest("You need to be logged in to see your rented items, if you have rented an item as Guest, please check your email that you privided when you rented the board");
            }
        }
        #endregion
    }
}
