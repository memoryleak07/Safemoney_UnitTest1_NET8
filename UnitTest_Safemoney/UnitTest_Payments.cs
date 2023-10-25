using Client.Classes._old;
using Client.Models.Safemoney.SMEnum;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest_Payments
    {
        private static string token;
        private static RestClient client;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            client = new RestClient("http", "192.168.34.212", 7409, "pin", "0000");
        }
        [TestMethod]
        public async Task Test1_CreatePay()
        {
            var payload = new
            {
                toBePaid = 5.10,
                description = "Cassa 1 - REP. PARAFARMACIA"
            };
            var res = await client.RequestManager.Pay(payload);
            Assert.AreEqual(ETransactionStatus.CREATED, res.Content.TransactionStatus);
            token = res.Content.Token; // Save the token
        }
        [TestMethod]
        public async Task Test2_BeginPay()
        {
            Thread.Sleep(2000);
            var payload = new
            {
                token = token,
            };
            var res = await client.RequestManager.PayBegin(payload);
            Assert.AreEqual(ETransactionStatus.CASH_IN, res.Content.TransactionStatus);
        }
        [TestMethod]
        public async Task Test3_DeletePay()
        {
            Thread.Sleep(2000);
            var payload = new
            {
                token = token,
            };
            var res = await client.RequestManager.PayDelete(payload);
            Assert.AreEqual(ETransactionStatus.ABORTED, res.Content.TransactionStatus);
        }
        [TestMethod]
        public async Task Test4_SendAbortedToken()
        {
            Thread.Sleep(2000);
            var payload = new
            {
                token = token,
            };
            var res = await client.RequestManager.PayBegin(payload);
            Assert.AreEqual(400, res.Error.Code); // 400 Bad Request is expected
        }
    }
}