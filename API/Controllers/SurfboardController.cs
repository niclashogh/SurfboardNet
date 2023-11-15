using API.Data;
using Lib.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SurfboardController : ControllerBase, IController<Surfboard>
    {
        #region Dependency Injections
        private readonly ProductContext productContext;

        public SurfboardController(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        #endregion

        #region [Post] AddAsync
        // Route: api/surfboard/add
        [HttpPost("surfboard/add"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<Surfboard>> AddAsync([Bind] Surfboard surfboard)
        {
            if (ModelState.IsValid)
            {
                productContext.Surfboard.Add(surfboard);
                await productContext.SaveChangesAsync();

                return Ok(productContext.Surfboard);
            }
            else
            {
                return Problem("Information is missing or something you typed wasn't allowed");
            }
            
        }
        #endregion

        #region [Put] EditAsync **Add concurrency logic **Checkout return type
        // Route: api/surfboard/edit/id
        [HttpPut("surfboard/edit/{id}"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<Surfboard>> EditAsync([FromBody, Bind] Surfboard surfboard)
        {
            if (ModelState.IsValid)
            {
                Surfboard? selected = await productContext.Surfboard.FindAsync(surfboard.Id);

                if (selected != null)
                {
                    productContext.Surfboard.Update(surfboard);
                    await productContext.SaveChangesAsync();

                    return Ok(productContext.Surfboard); //returns the updated context?
                }
                else
                {
                    return NotFound("The current product you are trying to edit doesn't exists");
                }
            }
            else
            {
                return BadRequest("Information is missing or something you typed wasn't allowed");
            }
        }
        #endregion

        #region [Delete] DeleteAsync
        // Route: api/surfboard/delete/id
        [HttpDelete("surfboard/delete/{id}"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<Surfboard>> DeleteAsync([FromQuery] int id)
        {
            if (productContext.Surfboard == null)
            {
                return NotFound("Due to the automatic dataseed of Surfboard items, there is an error loading or initializing the items");
            }

            Surfboard? selected = await productContext.Surfboard.FindAsync(id);

            if (selected != null)
            {
                productContext.Surfboard.Remove(selected);
                await productContext.SaveChangesAsync();

                return Ok(productContext.Surfboard);
            }
            else
            {
                return NotFound("The current product you are tying to delete was not found (or already removed)");
            }
        }
        #endregion

        #region [Get] GetAllAsync
        // Route: api/surfboards
        [HttpGet("surfboards")]
        public async Task<ActionResult<IEnumerable<Surfboard>>> GetAllAsync()
        {
            if (productContext.Surfboard == null)
            {
                return NotFound("Due to the automatic dataseed of Surfboard items, there is an error loading or initializing the items");
            }

            IEnumerable<Surfboard> surfboards = await productContext.Surfboard.ToListAsync();

            var jsonSerialized = JsonSerializer.Serialize(surfboards);
            return Ok(jsonSerialized);
        }
        #endregion
    }
}
