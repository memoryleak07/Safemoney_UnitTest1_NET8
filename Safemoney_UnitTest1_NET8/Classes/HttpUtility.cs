using System.Text;

namespace Client.Classes
{
    public class HttpUtility
    {
        public static HttpRequestMessage BuildRequestFromObject(HttpMethod method, string url, object payload)
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
