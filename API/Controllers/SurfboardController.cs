using Lib.Models.Product;
using Lib.Services.Data;
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
        private readonly CustomerContext userContext;
        private readonly EmployeeContext employeeContext;
        private readonly GuestContext guestContext;

        public SurfboardController(ProductContext productContext, CustomerContext userContext, EmployeeContext employeeContext, GuestContext guestContext)
        {
            this.productContext = productContext;
            this.userContext = userContext;
            this.employeeContext = employeeContext;
            this.guestContext = guestContext;
        }
        #endregion

        #region [Post] AddAsync
        [HttpPost("surfboard/add"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<Surfboard>> AddAsync()
        {

        }
        #endregion

        #region [Put] EditAsync
        [HttpPut("surfboard/edit/{id}"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<Surfboard>> EditAsync([FromQuery] int id)
        {

        }
        #endregion

        #region [Delete] DeleteAsync
        [HttpDelete("surfboard/delete/{id}"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<Surfboard>> DeleteAsync([FromQuery] int id)
        {

        }
        #endregion

        #region [Get] GetAllAsync
        // Route: api/surfboards
        [HttpGet("surfboards")]
        public async Task<ActionResult<IEnumerable<Surfboard>>> GetAllAsync()
        {
            if (productContext.Surfboard == null)
            {
                return NotFound("Due to the automatic dataseed of Surfboard items, there is an error loading or saving the items");
            }

            IEnumerable<Surfboard> surfboards = await productContext.Surfboard.ToListAsync();

            var jsonSerialized = JsonSerializer.Serialize(surfboards);
            return Ok(jsonSerialized);
        }
        #endregion
    }
}
