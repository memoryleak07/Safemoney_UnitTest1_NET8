using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Client.Classes
{
    public class HTTPClient
    {
        private string url;
        private HttpClient client = new HttpClient();
        public HTTPClient(string url) { this.url = url; }
        public HTTPClient(string url, string port) { this.url = $"{url}:{port}/"; }
        public HTTPClient(string address, string port, string username, string password)
        {
            url = $"http://{address}:{port}/";
            // Authorization Basic
            string authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authValue);
        }
        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            url = url + endpoint;
            return await client.GetAsync(url);
        }
        public async Task<HttpResponseMessage> PostAsJsonAsync(string endpoint, object? payload = null)
        {
            url = url + endpoint;
            return await client.PostAsJsonAsync(url, payload);
        }
        public async Task<HttpResponseMessage> PutAsJsonAsync(string endpoint, object? payload = null)
        {
            url = url + endpoint;
            return await client.PutAsJsonAsync(url, payload);
        }
        public async Task<HttpResponseMessage> DeleteAsJsonAsync(string endpoint, object? payload = null)
        {
            url = url + endpoint;
            var request = BuildRequestFromObject(HttpMethod.Delete, url, payload);
            return await client.SendAsync(request);
        }
        private HttpRequestMessage BuildRequestFromObject(HttpMethod method, string url, object payload)
        {
            // Serialize the payload to JSON
            string jsonPayload = JsonConvert.SerializeObject(payload);

            // Create StringContent with JSON payload and set the content type
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // Create an HttpRequestMessage with the method, URL, and content
            var request = new HttpRequestMessage(method, url);
            request.Content = content;

            return request;
        }
    }
}
