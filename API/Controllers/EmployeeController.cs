using Lib.Models.User;
using Lib.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase//, IController<Employee>
    {
        private readonly EmployeeContext employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }
    }
}
