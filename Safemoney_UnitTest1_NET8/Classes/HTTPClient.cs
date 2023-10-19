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
        public async Task<T> GetAsync<T>(string endpoint)
        {
            url = url + endpoint;
            HttpResponseMessage response = await client.GetAsync(url);
            return await ResponseManager.ReadResponse<T>(response);
        }
        public async Task<T> PostAsJsonAsync<T>(string endpoint, object? payload = null)
        {
            url = url + endpoint;
            HttpResponseMessage response = await client.PostAsJsonAsync(url, payload);
            return await ResponseManager.ReadResponse<T>(response);
        }
        public async Task<T> PutAsJsonAsync<T>(string endpoint, object? payload = null)
        {
            url = url + endpoint;
            HttpResponseMessage response = await client.PutAsJsonAsync(url, payload);
            return await ResponseManager.ReadResponse<T>(response);
        }
        public async Task<T> DeleteAsync<T>(string endpoint)
        {
            url = url + endpoint;
            HttpResponseMessage response = await client.DeleteAsync(url);
            return await ResponseManager.ReadResponse<T>(response);
        }
        //public async Task<T> DeleteAsync<T>(string endpoint)
        //{
        //    url = url + endpoint;
        //    HttpResponseMessage response = await client.DeleteAsync(url);
        //    return await ResponseManager.ReadResponse<T>(response);
        //}
    }
}
