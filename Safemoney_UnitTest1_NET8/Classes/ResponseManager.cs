using Client.Models;

namespace Client.Classes
{
    public class ResponseManager
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


        //public static async Task<T> ReadResponse<T>(Type modelType, HttpResponseMessage response)
        //{
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return await ManageBadResponse<T>(response);
        //    }
        //    var json = await response.Content.ReadAsStringAsync();
        //    return (T)JsonConvert.DeserializeObject(json, modelType);
        //}

        //private static async Task<T> ManageBadResponse<T>(HttpResponseMessage response)
        //{
        //    var error = new
        //    {
        //        Code = response.StatusCode,
        //        Message = response.ReasonPhrase,
        //    };
        //    var errorJson = JsonConvert.SerializeObject(error);
        //    return JsonConvert.DeserializeObject<T>(errorJson);
        //}
    }
}
