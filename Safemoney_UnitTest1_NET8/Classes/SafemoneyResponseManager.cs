using Client.Models.SMModels;

namespace Client.Classes
{
    public class SafemoneyResponseManager
    {
        public static async Task<SMResponse<T>> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = new SMError 
                { 
                    Code = (int)response.StatusCode, 
                    Reason = response.ReasonPhrase 
                };
                return SMResponse<T>.CreateErrorResponse(error);
            }

            var contentString = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(contentString);
            return SMResponse<T>.CreateSuccessResponse(content);
        }
    }
}
