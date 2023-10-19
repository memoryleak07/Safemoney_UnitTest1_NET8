using Safemoney_UnitTest1_NET8.Classes;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest1
    {
        public HTTPClient client;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient and set AssistMode = false
        {
            //client = new RestClient("192.168.34.213", "7409", "pin", "0000");
            client = new HTTPClient("https://httpbin.org/");
        }
        [TestMethod]
        public async Task TestGetAsync()
        {
            var res = await client.GetAsync<dynamic>("get");
        }
        [TestMethod]
        public async Task TestPostAsJsonAsync()
        {
            var payload = new
            {
                toBePaid = 5.70,
                description = "Cassa 1 - REP. PARAFARMACIA"
            };
            var res = await client.PostAsJsonAsync<dynamic>("post", payload);
            Console.WriteLine(res);
        }
        [TestMethod]
        public async Task TestDeleteAsync()
        {
            var res = await client.DeleteAsync<dynamic>("delete");
            Console.WriteLine(res);
        }
        [TestMethod]
        public async Task TestPutAsJsonAsync()
        {
            var res = await client.PutAsJsonAsync<dynamic>("put"); // Or pass object as payload
            Console.WriteLine(res);
        }
        //[TestMethod]
        //public async Task TestMethodPostAsync()
        //{
        //    // Create an object with the desired structure
        //    var data = new
        //    {
        //        toBePaid = 5.70,
        //        description = "Cassa 1 - REP. PARAFARMACIA"
        //    };

        //    // Serialize the object to JSON
        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

        //    // Create a StringContent with the JSON data
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    // Make the POST request with the content
        //    dynamic res = await client.PostAsync<dynamic>("pay", content);
        //    Console.WriteLine(res.ToString());
        //}
    }
}