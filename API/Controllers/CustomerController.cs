using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase//, IController<Customer>
    {
        private readonly CustomerContext customerContext;

        public CustomerController(CustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }
    }
}
