using Client.Classes._old;

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
            var res = await client.HttpClient.GetAsync("get");
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test2_TestPostAsync()
        {
            var res = await client.HttpClient.PostAsync("post", null);
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test3_TestBasicAuth()
        {
            string url = "https://httpbin.org/basic-auth/foo/bar";
            string username = "foo";
            string password = "bar";
            // Init client add Basic Auth 
            client = new RestClient(url, username, password);
            var res = await client.HttpClient.GetAsync(url);
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test4_TestMyGetMethod()
        {
            var res = await client.RequestManager.MyGetMethodAsync();
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test5_TestMyPostMethod()
        {
            var payload = new
            {
                k1 = "uno",
                k2 = "due"
            };
            var res = await client.RequestManager.MyPostMethodAsync(payload);
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test6_TestMyPutMethod()
        {
            var res = await client.RequestManager.MyPutMethodAsync();
            Assert.AreEqual(200, (int)res.StatusCode);
        }
        [TestMethod]
        public async Task Test7_TestMyDeleteMethod()
        {
            var res = await client.RequestManager.MyDeleteMethodAsync();
            Assert.AreEqual(200, (int)res.StatusCode);
        }
    }
}
