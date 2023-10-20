using Client.Classes;
using Client.Models;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest1
    {
        private static string token;
        private static RestClient rest;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient and set AssistMode = false
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
            SMPayCreated res = await rest.Pay(payload);
            Assert.AreEqual(SMTransactionStatus.CREATED, res.TransactionStatus);
            token = res.Token; // Save the token
        }
        [TestMethod]
        public async Task Test2_BeginPay()
        {
            var payload = new
            {
                token = token,
            };
            SMPay res = await rest.PayBegin(payload);
            Assert.AreEqual(SMTransactionStatus.CASH_IN, res.TransactionStatus);
        }
        [TestMethod]
        public async Task Test2_DeletePay()
        {
            var payload = new
            {
                token = token,
            };
            SMPay res = await rest.PayDelete(payload);
            Assert.AreEqual(SMTransactionStatus.ABORTED, res.TransactionStatus);
        }
    }
}