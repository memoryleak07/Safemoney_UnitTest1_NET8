using Client.Models.Safemoney.SMEnum;
using Client.Models.Safemoney.SMModels;
using Newtonsoft.Json;

namespace UnitTestSafemoney.TestJsonResponses
{
    [TestClass]
    public class UnitTest_DeviceStatus
    {
        private SMDeviceStatus res;

        [TestInitialize]
        public void TestInitialize() // Initialize the Test
        {
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
            string filePath = Path.Combine(projectDirectory, "TestJsonResponses", "testDeviceStatus.json");

            var response = File.ReadAllText(filePath);
            // Convert response in SMDeviceStatus
            res = JsonConvert.DeserializeObject<SMDeviceStatus>(response);
        }
        [TestMethod]
        public async Task Test1_CheckTotalCount()
        {
            Assert.AreEqual(10, res.TotalCount);
        }
        [TestMethod]
        public async Task Test2_CheckDeviceStatus()
        {
            Assert.AreEqual(EDeviceStatus.OFFLINE, res.DeviceStatus);
        }
        [TestMethod]
        public async Task Test3_CheckFirstStatusInfoData()
        {
            Assert.AreEqual("NA_POWER", res.StatusInfo[0].Data.UID);
        }
        [TestMethod]
        public async Task Test4_CheckFirstStatusInfoInError()
        {
            Assert.IsFalse(res.StatusInfo[0].Data.InError);
        }
        [TestMethod]
        public async Task Test5_CheckFirstStatusInfoType()
        {
            Assert.IsInstanceOfType(res.StatusInfo[0].Data.Type, typeof(int));
        }
    }
}
