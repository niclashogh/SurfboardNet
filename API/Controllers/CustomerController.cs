using Lib.Models.User;
using Lib.Services.Data;
using Microsoft.AspNetCore.Http;
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
