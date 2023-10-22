using Client.Models;
using Client.Models.SMEnum;
using Newtonsoft.Json;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest_TransactionsLog
    {
        private SMTransactionsLog res;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
            string filePath = Path.Combine(projectDirectory, "TestJsonResponses", "testTransactionsLog.json");

            var response = File.ReadAllText(filePath);
            // Convert response in SMTransactionsLogBase
            res = JsonConvert.DeserializeObject<SMTransactionsLog>(response);
        }
        [TestMethod]
        public async Task Test1_CheckTotalCount()
        {
            Assert.AreEqual(29, res.TotalCount);
        }
        [TestMethod]
        public async Task Test2_CheckFirstTransactionId()
        {
            Assert.AreEqual("625543f66021fa02daaa1c76", res.TransactionsLog[0].Id);
        }
        [TestMethod]
        public async Task Test3_CheckFirstTransactionTransactionCode()
        {
            Assert.AreEqual(ETransactionCode.PAY, res.TransactionsLog[0].TransactionCode);
        }
        [TestMethod]
        public async Task Test4_CheckFirstTransactionTotalRequest()
        {
            Assert.AreEqual(0.05, res.TransactionsLog[0].TotalRequest);
        }
        [TestMethod]
        public async Task Test5_CheckFirstTransactionTransactionStatus()
        {
            Assert.AreEqual(ETransactionStatus.TERMINATED, res.TransactionsLog[0].TransactionStatus);
        }
        [TestMethod]
        public async Task Test6_CheckFirstTransactionResDescription()
        {
            Assert.AreEqual("success", res.TransactionsLog[0].ResDescription.ToLower());
        }
        [TestMethod]
        public async Task Test7_CheckFirstTransactionLevels()
        {
            Assert.AreEqual(null, res.TransactionsLog[0].Levels);
        }
        [TestMethod]
        public async Task Test8_CheckForEmptyCashTotal()
        {
            foreach (var ts in res.TransactionsLog)
            {
                if (ts.TransactionCode == ETransactionCode.EMPTY_CASH_TOTAL_SET)
                {
                    Assert.AreEqual("EUR", ts.Levels.Currency);
                    Assert.IsNotNull(ts.Levels.Coins);
                    Assert.AreEqual(70, ts.Levels.Total);
                    Assert.AreEqual(0, ts.Levels.ResCode);
                    Assert.AreEqual(0, ts.Levels.Coins.Total);
                    Assert.AreEqual(70, ts.Levels.Notes.Total);
                    Assert.AreEqual("success", ts.Levels.ResDescription.ToLower());
                    Assert.AreEqual(EDeviceType.NOTE, ts.Levels.Notes.Denominations[0].DeviceType);
                    Assert.IsNull(ts.User);
                }
            }
            
        }
    }
}
