using Microsoft.AspNetCore.Mvc;

namespace Rent.Services
{
    public interface IApi <T> where T : class
    {
        Task AddAsync(string apiUrl, T model);

        Task EditAsync(string apiUrl, int id, T model);

        Task DeleteAsync(string apiUrl, int id);

        Task<object> GetAllAsync(string apiUrl);
    }
}
