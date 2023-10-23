using Client.Models;
using Client.Models.SMEnum;
using Newtonsoft.Json;

namespace UnitTestSafemoney.TestJsonResponses
{
    [TestClass]
    public class UnitTest_CashWithdrawLevel
    {
        private SMCashWithdraw res;

        [TestInitialize]
        public void TestInitialize() // Initialize the Test
        {
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
            string filePath = Path.Combine(projectDirectory, "TestJsonResponses", "testPOSTCashWithdrawLevel.json");

            var response = File.ReadAllText(filePath);
            // Convert response in SMDeviceStatus
            res = JsonConvert.DeserializeObject<SMCashWithdraw>(response);
        }
        [TestMethod]
        public async Task Test1_CheckFirstWwithdrawalsDispensed()
        {
            Assert.AreEqual(0, res.Withdrawals[0].Dispensed);
        }
        [TestMethod]
        public async Task Test2_CheckFirstWwithdrawalsNotDispensed()
        {
            Assert.AreEqual(5, res.Withdrawals[0].NotDispensed);
        }
        [TestMethod]
        public async Task Test3_CheckFirstWwithdrawalsDenomination()
        {
            Assert.AreEqual(1, res.Withdrawals[0].Denomination);
        }
        [TestMethod]
        public async Task Test4_CheckFirstWwithdrawalsDeviceType()
        {
            Assert.AreEqual(EDeviceType.COIN, res.Withdrawals[0].DeviceType);
        }
        [TestMethod]
        public async Task Test5_CheckTransactionStatus()
        {
            Assert.AreEqual(ETransactionStatus.TERMINATED, res.TransactionStatus);
        }
        [TestMethod]
        public async Task Test6_PostCashWithdrawLevel()
        {
            // Post Withdraw
            SMDenominations cashList = new(EDeviceType.COIN, 1, 5);
            RestClient client = new RestClient("https://httpbin.org/");
            HttpRequestMessage request = HttpUtility.BuildRequestMessageFromObject(HttpMethod.Post, "post", cashList);
            var response = await client.HttpClient.SendAsync(request);

            Assert.AreEqual(200, (int)response.StatusCode);
        }
    }
}
