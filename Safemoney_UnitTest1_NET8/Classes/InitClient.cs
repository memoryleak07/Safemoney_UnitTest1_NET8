using Client.Controllers;

namespace Client.Classes
{
    public class InitClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _clientName;

        public InitClient(IHttpClientFactory clientFactory, string clientName)
        {
            _clientFactory = clientFactory;
            _clientName = clientName;
        }

        public SafemoneyController CreateSafemoneyController(string baseAddress)
        {
            using HttpClient httpClient = _clientFactory.CreateClient(_clientName);

            // Set the base address for the HttpClient
            httpClient.BaseAddress = new Uri(baseAddress);

            return new SafemoneyController(httpClient);
        }

    }
}

//https://stackoverflow.com/questions/56739903/is-it-possible-to-inject-ihttpclientfactory-to-a-strongly-typed-client
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2#typed-clients
//https://learn.microsoft.com/it-it/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests