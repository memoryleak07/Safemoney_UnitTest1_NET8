namespace Client.Classes
{
    public class ResponseManager
    {
        public static async Task<T> ReadResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return await ManageBadResponse<T>(response);
            }
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static async Task<T> ManageBadResponse<T>(HttpResponseMessage response)
        {
            var error = new
            {
                Code = response.StatusCode,
                Message = response.ReasonPhrase,
            };
            var errorJson = JsonConvert.SerializeObject(error);
            return JsonConvert.DeserializeObject<T>(errorJson);
        }
    }
}
