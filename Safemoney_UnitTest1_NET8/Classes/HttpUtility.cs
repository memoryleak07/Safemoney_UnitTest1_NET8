using System.Net.Http.Headers;
using System.Text;

namespace Client.Classes
{
    public class HttpUtility
    {
        public static void AddHttpRequestHeaders(HttpClient client, string username, string password)
        {
            // Create the Authorization header and set it directly on the HttpClient headers
            string authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authValue);

            // Set the default Accept header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static HttpRequestMessage BuildRequestMessageFromObject(HttpMethod method, string url, object payload)
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
