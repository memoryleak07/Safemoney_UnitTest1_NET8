namespace Client.Classes
{
    public class RestClient
    {
        public HttpClient client = new(); // Init a new instance of the HttpClient
        public HttpClient HttpClient => client; // Expose the HttpClient to use built-in methods 
        public HttpRequestManager RequestManager { get; } // Include an instance of HttpRequestManager
        public RestClient(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);
            RequestManager = new HttpRequestManager(client);
        }
        public RestClient(string baseAddress, int port)
        {
            client.BaseAddress = HttpUtility.BuildUrl(null, baseAddress, port);
            RequestManager = new HttpRequestManager(client);
        }
        public RestClient(string baseAddress, string username, string password)
        {
            client.BaseAddress = new Uri(baseAddress);
            HttpUtility.AddHttpRequestHeaders(client, username, password);
            RequestManager = new HttpRequestManager(client);
        }
        public RestClient(string? scheme, string baseAddress, int? port, string username, string password)
        {
            client.BaseAddress = HttpUtility.BuildUrl(scheme, baseAddress, port);
            HttpUtility.AddHttpRequestHeaders(client, username, password);
            RequestManager = new HttpRequestManager(client);
        }
    }
}
