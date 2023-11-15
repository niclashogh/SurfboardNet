using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lib.Models.Obtain;
using Rent.Data;

namespace Rent.Controllers
{
    public class RentalController : Controller
    {
        private readonly ProductContext productContext;

        public RentalController(ProductContext context)
        {
            productContext = context;
        }


    }
}
