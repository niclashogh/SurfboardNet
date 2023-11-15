using Microsoft.AspNetCore.Mvc;

namespace Rent.Controllers
{
    public interface IController<T> where T : class
    {
        Task<IActionResult> Index();

        IActionResult Create();

        Task<IActionResult> Create(T model);

        Task<IActionResult> Edit(int? id);

        Task<IActionResult> Edit(T model);

        Task<IActionResult> Delete(int? id);

        Task<IActionResult> Delete(int id);
    }
}
