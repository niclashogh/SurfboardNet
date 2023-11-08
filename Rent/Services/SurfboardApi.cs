using AspNetCore;
using Lib.Models.Product;
using Lib.Services.Data;
using System.Text.Json;

namespace Rent.Services
{
    public class SurfboardApi : IApi<Surfboard>
    {
        #region Dependency Injections
        private readonly HttpClient httpClient = new();
        private readonly ProductContext productContext;

        public SurfboardApi(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        #endregion

        #region AddAsync
        public async Task AddAsync(string apiUrl, Surfboard surfboard)
        {
            try
            {
                if (surfboard == null)
                {
                    // Message to API
                    var jsonSerializedModel = JsonSerializer.Serialize(surfboard);
                    await httpClient.PostAsJsonAsync(apiUrl, jsonSerializedModel);
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        #endregion

        #region EditAsync
        public async Task EditAsync(string apiUrl, int id, Surfboard surfboard)
        {
            try
            {
                if (surfboard != null)
                {
                    // Message to API
                    var jsonSerializedModel = JsonSerializer.Serialize(surfboard);
                    await httpClient.PostAsJsonAsync(apiUrl, jsonSerializedModel);
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        #endregion

        #region DeleteAsync
        public async Task DeleteAsync(string apiUrl, int id)
        {
            try
            {
                Surfboard? selected = await productContext.Surfboard.FindAsync(id);

                if (selected != null)
                {
                    // Message to API
                    var jsonSerializedModel = JsonSerializer.Serialize(selected);
                    await httpClient.PostAsJsonAsync(apiUrl, jsonSerializedModel);
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        #endregion

        #region GetAllAsync **Reconsider the valid return types
        public async Task<object> GetAllAsync(string apiUrl)
        {
            try
            {
                // Responce from API
                var apiResponse = await httpClient.GetAsync(apiUrl);

                if (apiResponse != null)
                {
                    try
                    {
                        //Converting the response to a valid return type
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
                return "Failed doing the API call";
            }
        }
        #endregion
    }
}
