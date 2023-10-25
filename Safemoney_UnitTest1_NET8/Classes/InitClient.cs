using Client.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SafemoneyController CreateSafemoneyController(string baseAddress, string username, string password)
        {
            // Creates and configures an instance using the configuration that corresponds to the logical name specified
            HttpClient httpClient = _clientFactory.CreateClient(_clientName);
            // Set the base address for the HttpClient
            httpClient.BaseAddress = new Uri(baseAddress);
            // Add basic Baic Auth to httpClient RequestHeaders
            HttpUtility.AddHttpRequestHeaders(httpClient, username, password);
            // Return new instance of the Safemoney Controller
            return new SafemoneyController(httpClient);
        }
    }
}

//https://stackoverflow.com/questions/56739903/is-it-possible-to-inject-ihttpclientfactory-to-a-strongly-typed-client
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2#typed-clients
//https://learn.microsoft.com/it-it/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests