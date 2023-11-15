namespace API.Service.Api
{
    public class RentalApi// : IApi<Rental>
    {
        private readonly HttpClient httpClient;

        public RentalApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
