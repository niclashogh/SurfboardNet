namespace API.Service.Api
{
    public interface IApi <T> where T : class
    {
        Task AddAsync(string apiUrl, T model);

        Task EditAsync(string apiUrl, T model);

        Task DeleteAsync(string apiUrl, int id);

        Task<object> GetAllAsync(string apiUrl);
    }
}
