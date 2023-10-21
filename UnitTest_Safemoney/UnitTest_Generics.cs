using Client.Classes;
using System.Net.Http.Headers;
using System.Text;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest_Generics
    {
        private static RestClient client;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            client = new RestClient("https://httpbin.org/");
        }
        [TestMethod]
        public async Task Test1_TestGetAsync()
        {
            var res = await client.GetAsync("get");
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test2_TestPostAsync()
        {
            var res = await client.PostAsync("post", null);
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test3_TestBasicAuth()
        {
            string username = "foo";
            string password = "bar";
            string url = "https://httpbin.org/basic-auth/foo/bar";

            // Create the Authorization header and set it directly on the HttpClient headers
            string authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authValue);

            // Set the default Accept header if needed
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var authorizationHeader = client.DefaultRequestHeaders.Authorization;

            Console.WriteLine(authorizationHeader);
            var res = await client.GetAsync(url);
            Assert.AreEqual(200, (int)res.StatusCode);
        }
    }
}
