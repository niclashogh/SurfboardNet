using Lib.Models.Product;
using Lib.Services.Data;
using Microsoft.AspNetCore.Authorization;
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
            surfboardApi = new(productContext);
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index() => View(surfboardApi.GetAllAsync("https://localhost:7051/api/surfboards"));

        #region Create Methods
        // Route: Surfboards/Create
        [HttpGet]
        public IActionResult Create() => View(); // Think as the acualty edit page

        // Route: Surfboards/Create
        [HttpPost, Authorize(Roles = "Employee")]
        public async Task<IActionResult> Create([Bind] Surfboard surfboard) // Think as the button-action
        {
            await surfboardApi.AddAsync("https://localhost:7051/api/surfboard/add", surfboard);
            
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit Methods
        // Route: Surfboards/Edit/id
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Surfboard? selected = await productContext.Surfboard.FindAsync(id);

                if (selected != null)
                {
                    return View(selected);
                }
                else
                {
                    return NotFound("The product that you are trying to edit was not found");
                }
            }
            return BadRequest();
        }

        // Route: Surfboards/Edit/id
        [HttpPost, Authorize(Roles = "Employee")]
        public async Task<IActionResult> Edit([FromBody, Bind] Surfboard surfboard)
        {
            await surfboardApi.EditAsync("", surfboard);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete Methods
        // Route: Surfboards/Delete/id
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Surfboard? selected = await productContext.Surfboard.FindAsync(id);
                
                if (selected != null)
                {
                    return View(selected);
                }
                else
                {
                    return NotFound("The product that you are trying to delete was not found");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // Route: Surfboards/Delete/id
        [HttpPost, Authorize(Roles = "Employee")]
        public async Task<IActionResult> Delete(int id)
        {
            await surfboardApi.DeleteAsync("", id);

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
