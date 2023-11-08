using Lib.Models.Service;

namespace Rent.Services
{
    public class RentalApi : IApi<Rental>
    {
        private readonly HttpClient httpClient;

        public RentalApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
