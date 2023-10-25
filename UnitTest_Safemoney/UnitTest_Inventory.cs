using Client.Classes._old;
using Client.Models.SMEnum;
using Client.Models.SMModels;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest_Inventory
    {
        private static RestClient client;
        private static SMResponse<SMInventory> res;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            client = new RestClient("http", "192.168.34.212", 7409, "pin", "0000");
        }
        [TestMethod]
        public async Task Test1_CallGetInventory()
        {
            res = await client.RequestManager.GetInventoryAsync();
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public async Task Test1_CheckTotal()
        {
            Assert.AreEqual(0, (int)res.Content.Total);
        }
        [TestMethod]
        public async Task Test2_CheckResCode()
        {
            Assert.AreEqual(0, res.Content.ResCode);
        }
        [TestMethod]
        public async Task Test3_CheckResDescription()
        {
            Assert.AreEqual("success", res.Content.ResDescription.ToLower());
        }
        [TestMethod]
        public async Task Test4_CheckFirstDenomination()
        {
            Assert.AreEqual(0.01, (double)res.Content.Coins.Denominations[0].Denomination);
        }
        [TestMethod]
        public async Task Test5_CheckLastDenomination()
        {
            Assert.AreEqual(200, (long)res.Content.Notes.Denominations[5].Denomination);
        }
        [TestMethod]
        public async Task Test6_CheckFirstDenominationRoute()
        {
            Assert.AreEqual(ERoute.NONE, res.Content.Coins.Denominations[0].Route);
        }
        [TestMethod]
        public async Task Test7_CheckLastDenominationRoute()
        {
            Assert.AreEqual(ERoute.DEPOSIT, res.Content.Notes.Denominations[5].Route);
        }
        // Check total for coin
        [TestMethod]
        public async Task Test8_CheckTotalsCoinsDenominations()
        {
            Assert.AreEqual(0, res.Content.Coins.Total);
        }
        [TestMethod]
        public async Task Test9_CheckTotalsNotesDenomination()
        {
            Assert.AreEqual(0, res.Content.Notes.Total);
        }
    }
}
