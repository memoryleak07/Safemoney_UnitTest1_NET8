using Client.Models.Safemoney.SMEnum;
using Client.Models.Safemoney.SMModels;
using Newtonsoft.Json;

namespace UnitTestSafemoney.TestJsonResponses
{
    [TestClass]
    public class UnitTest_Inventory
    {
        private SMInventory res;

        [TestInitialize]
        public void TestInitialize()
        {
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
            string filePath = Path.Combine(projectDirectory, "TestJsonResponses", "testInventory.json");

            var response = File.ReadAllText(filePath);
            // Convert response in SMInventory
            res = JsonConvert.DeserializeObject<SMInventory>(response);
        }
        [TestMethod]
        public async Task Test1_CheckTotal()
        {
            Assert.AreEqual(0, res.Total);
        }
        [TestMethod]
        public async Task Test2_CheckResCode()
        {
            Assert.AreEqual(0, res.ResCode);
        }
        [TestMethod]
        public async Task Test3_CheckResDescription()
        {
            Assert.AreEqual("success", res.ResDescription.ToLower());
        }
        [TestMethod]
        public async Task Test4_CheckFirstDenomination()
        {
            Assert.AreEqual(0.01, (double)res.Coins.Denominations[0].Denomination);
        }
        [TestMethod]
        public async Task Test5_CheckLastDenomination()
        {
            Assert.AreEqual(200, (long)res.Notes.Denominations[5].Denomination);
        }
        [TestMethod]
        public async Task Test6_CheckFirstDenominationRoute()
        {
            Assert.AreEqual(ERoute.NONE, res.Coins.Denominations[0].Route);
        }
        [TestMethod]
        public async Task Test7_CheckLastDenominationRoute()
        {
            Assert.AreEqual(ERoute.DEPOSIT, res.Notes.Denominations[5].Route);
        }
        // Check total for coin
        [TestMethod]
        public async Task Test8_CheckTotalsCoinsDenominations()
        {
            Assert.AreEqual(0, res.Coins.Total);
        }
        [TestMethod]
        public async Task Test9_CheckTotalsNotesDenomination()
        {
            Assert.AreEqual(0, res.Notes.Total);
        }
    }
}
