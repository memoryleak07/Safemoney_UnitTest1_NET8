using Client.Models.SMEnum;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Security.Principal;
using System;
using Newtonsoft.Json.Converters;
using Client.Models.SMModels;

namespace UnitTestSafemoney
{
    [TestClass]
    public class UnitTest_Withdrawals
    {
        private static RestClient client;

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            client = new RestClient("http", "192.168.34.212", 7409, "pin", "0000");
        }
        [TestMethod]
        public async Task Test1_CallGetInventory()
        {
            var res = await client.RequestManager.GetCashWithdrawLevel();
            Assert.AreEqual("eur", res.Content.Currency.ToLower());
        }
        [TestMethod]
        public async Task Test2_CallGetInventory()
        {
            //double oneCent = Convert.ToDouble(EurDenomination.Eur_01) / 100;
            double oneCent = EDenomination.ToDouble(EurDenomination.Eur_01);

            var res = await client.RequestManager.GetCashWithdrawLevel();
            Assert.AreEqual("eur", res.Content.Currency.ToLower());
        }

        [TestMethod]
        public async Task Test1_CheckTotal()
        {
            // Create the SMCashLevel object with the desired cashList
            SMCashLevel cashLevel = new SMCashLevel
            {
                CashList = new List<SMDenominations>
                {
                    new SMDenominations(EDeviceType.NOTE, EurDenomination.Eur_50, 1)
                }
            };

            var jsonPayload = JsonConvert.SerializeObject(cashLevel, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = { new StringEnumConverter()/*, new EurDenominationConverter()*/ }
            });

            Console.WriteLine(jsonPayload);
            var res = await client.RequestManager.PostCashWithdrawLevel(jsonPayload);
            Assert.AreEqual(10, (int)res.Content.TotalDispensed);
        }
        //[TestMethod]
        //public async Task Test2_CheckResCode()
        //{
        //    Assert.AreEqual(0, res.Content.ResCode);
        //}
        //[TestMethod]
        //public async Task Test3_CheckResDescription()
        //{
        //    Assert.AreEqual("success", res.Content.ResDescription.ToLower());
        //}
        //[TestMethod]
        //public async Task Test4_CheckFirstDenomination()
        //{
        //    Assert.AreEqual(0.01, (double)res.Content.Coins.Denominations[0].Denomination);
        //}
        //[TestMethod]
        //public async Task Test5_CheckLastDenomination()
        //{
        //    Assert.AreEqual(200, (long)res.Content.Notes.Denominations[5].Denomination);
        //}
        //[TestMethod]
        //public async Task Test6_CheckFirstDenominationRoute()
        //{
        //    Assert.AreEqual(ERoute.NONE, res.Content.Coins.Denominations[0].Route);
        //}
        //[TestMethod]
        //public async Task Test7_CheckLastDenominationRoute()
        //{
        //    Assert.AreEqual(ERoute.DEPOSIT, res.Content.Notes.Denominations[5].Route);
        //}
        //// Check total for coin
        //[TestMethod]
        //public async Task Test8_CheckTotalsCoinsDenominations()
        //{
        //    Assert.AreEqual(0, res.Content.Coins.Total);
        //}
        //[TestMethod]
        //public async Task Test9_CheckTotalsNotesDenomination()
        //{
        //    Assert.AreEqual(0, res.Content.Notes.Total);
        //}
    }
}
