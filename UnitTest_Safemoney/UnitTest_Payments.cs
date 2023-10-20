using Client.Classes;
using Client.Models;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest_Payments
    {
        private static string token;
        private static RestClient rest;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            rest = new RestClient("192.168.34.212", "7409", "pin", "0000");
        }
        [TestMethod]
        public async Task Test1_CreatePay()
        {
            var payload = new
            {
                toBePaid = 5.10,
                description = "Cassa 1 - REP. PARAFARMACIA"
            };
            var res = await rest.Pay(payload);
            Assert.AreEqual(SMTransactionStatus.CREATED, res.Content.TransactionStatus);
            token = res.Content.Token; // Save the token
        }
        [TestMethod]
        public async Task Test2_BeginPay()
        {
            var payload = new
            {
                token = token,
            };
            var res = await rest.PayBegin(payload);
            Assert.AreEqual(SMTransactionStatus.CASH_IN, res.Content.TransactionStatus);
        }
        [TestMethod]
        public async Task Test3_DeletePay()
        {
            var payload = new
            {
                token = token,
            };
            var res = await rest.PayDelete(payload);
            Assert.AreEqual(SMTransactionStatus.ABORTED, res.Content.TransactionStatus);
        }
        [TestMethod]
        public async Task Test4_SendAbortedToken()
        {
            var payload = new
            {
                token = token,
            };
            var res = await rest.PayBegin(payload);
            Assert.AreEqual(400, res.Error.Code); // 400 Bad Request is expected
        }
    }
}