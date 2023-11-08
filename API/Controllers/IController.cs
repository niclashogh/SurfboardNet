using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public interface IController<T> where T : class
    {
        Task<ActionResult<T>> AddAsync(T model);

        Task<ActionResult<T>> EditAsync(T model);

        Task<ActionResult<T>> DeleteAsync(int id);

        Task<ActionResult<IEnumerable<T>>> GetAllAsync();
    }
}
