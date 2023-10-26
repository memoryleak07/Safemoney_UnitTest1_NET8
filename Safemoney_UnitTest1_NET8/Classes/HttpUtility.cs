﻿using System.Net.Http.Headers;
using System.Text;

namespace Client.Classes
{
    public class HttpUtility
    {
        public static Uri BuildUrl(string? scheme, string baseAddress, int? port = null)
        {
            UriBuilder urlBuilder = new ()
            {
                Scheme = scheme,
                Host = baseAddress,
            };
            if (port.HasValue)
            {
                urlBuilder.Port = port.Value;
            }

            return urlBuilder.Uri;
        }
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
            StringContent content = new (jsonPayload, Encoding.UTF8, "application/json");

            // Create an HttpRequestMessage with the method, URL, and content
            HttpRequestMessage request = new (method, url);
            request.Content = content;

            return request;
        }
    }
}
