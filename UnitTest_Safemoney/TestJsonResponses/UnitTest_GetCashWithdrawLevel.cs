using Client.Models;
using Client.Models.SMEnum;
using Newtonsoft.Json;

namespace UnitTestSafemoney.TestJsonResponses
{
    [TestClass]
    public class UnitTest_GetCashWithdrawLevel
    {
        private SMCashLevel res;

        [TestInitialize]
        public void TestInitialize() // Initialize the Test
        {
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
            string filePath = Path.Combine(projectDirectory, "TestJsonResponses", "testGETCashWithdrawLevel.json");

            var response = File.ReadAllText(filePath);
            // Convert response in SMDeviceStatus
            res = JsonConvert.DeserializeObject<SMCashLevel>(response);
        }
        [TestMethod]
        public async Task Test1_CheckFirstDenomination()
        {
            Assert.AreEqual(EurDenomination.Eur_01, res.Withdrawals[0].Denomination);
        }
        [TestMethod]
        public async Task Test2_CheckFirstDeviceType()
        {
            Assert.AreEqual(EDeviceType.COIN, res.Withdrawals[0].DeviceType);
        }
        [TestMethod]
        public async Task Test3_CheckFirstQuantity()
        {
            Assert.AreEqual(0, res.Withdrawals[0].Quantity);
        }
    }
}
