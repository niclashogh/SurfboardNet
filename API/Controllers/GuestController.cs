using Lib.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class GuestController : ControllerBase//, IController<Guest>
    {
        private readonly GuestContext guestContext;

        public GuestController(GuestContext guestContext)
        {
            this.guestContext = guestContext;
        }
    }
}
