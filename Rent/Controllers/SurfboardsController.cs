using Lib.Models.Product;
using Lib.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Rent.Services;

namespace Rent.Controllers
{
    public class SurfboardsController : Controller
    {
        #region Dependency Injections
        private readonly ProductContext productContext;
        private readonly SurfboardApi surfboardApi;

        public SurfboardsController(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        #endregion

        public async Task<IActionResult> Index() => View(surfboardApi.GetAllAsync("https://localhost:7051/api/surfboards"));

        public IActionResult Create() => View();

        public async Task<IActionResult> Create([Bind] Surfboard surfboard) => View(surfboardApi.AddAsync("", surfboard));
    }
}
