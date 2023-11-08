using Lib.Models.Product;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Text.Json;

namespace Rent.Services
{
    public class SurfboardApi : IApi<Surfboard>
    {
        private readonly HttpClient httpClient;

        public SurfboardApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        #region AddAsync
        public async Task AddAsync(string apiUrl, Surfboard surfboard)
        {
            try
            {
                await httpClient.PostAsync(apiUrl, surfboard);
                httpClient.SendAsync();
            }
        }
        #endregion

        #region EditAsync
        public async Task EditAsync(string apiUrl, int id)
        {

        }
        #endregion

        #region DeleteAsync
        public async Task DeleteAsync(string apiUrl, int id)
        {

        }
        #endregion

        #region GetAllAsync
        public async Task<object> GetAllAsync(string apiUrl)
        {
            try
            {
                var apiResponse = await httpClient.GetAsync(apiUrl);

                if (apiResponse != null)
                {
                    try
                    {
                        var jsonSerialize = await apiResponse.Content.ReadAsStringAsync();
                        IEnumerable<Surfboard> deserializedModel = JsonSerializer.Deserialize<IEnumerable<Surfboard>>(jsonSerialize);

                        return deserializedModel;
                    }
                    catch
                    {
                        return await apiResponse.Content.ReadAsStringAsync();
                    }
                }
                else
                {
                    return "The api response was empty";
                }
            }
            catch
            {
                return "Failed doing the api call";
            }
        }
        #endregion
    }
}
