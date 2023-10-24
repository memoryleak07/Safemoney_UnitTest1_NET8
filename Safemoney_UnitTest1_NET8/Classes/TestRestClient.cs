using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes
{
    public class TestRestClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _clientName;
        private readonly HttpClient _httpClient;
        private readonly HttpRequestManager _requestManager;

        public HttpClient HttpClient => _httpClient;
        public HttpRequestManager RequestManager => _requestManager;

        public TestRestClient(IHttpClientFactory clientFactory, string clientName)
        {
            _clientFactory = clientFactory;
            _clientName = clientName;
            _httpClient = _clientFactory.CreateClient(clientName);
            _requestManager = new HttpRequestManager(_httpClient);
        }
    }
}
