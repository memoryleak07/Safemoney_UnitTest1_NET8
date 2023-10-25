using Client.Models.Safemoney.SMModels;

namespace Client.Classes
{
    public class SafemoneyResponseManager
    {
        public static async Task<SMBaseResponse<T>> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = new SMError 
                { 
                    Code = (int)response.StatusCode, 
                    Reason = response.ReasonPhrase 
                };
                return SMBaseResponse<T>.CreateErrorResponse(error);
            }

            var contentString = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(contentString);
            return SMBaseResponse<T>.CreateSuccessResponse(content);
        }
    }
}
