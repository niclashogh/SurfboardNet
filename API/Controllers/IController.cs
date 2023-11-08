using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public interface IController<T> where T : class
    {
        Task<ActionResult<T>> AddAsync();

        Task<ActionResult<T>> EditAsync(int id);

        Task<ActionResult<T>> DeleteAsync(int id);

        Task<ActionResult<IEnumerable<T>>> GetAllAsync();
    }
}
