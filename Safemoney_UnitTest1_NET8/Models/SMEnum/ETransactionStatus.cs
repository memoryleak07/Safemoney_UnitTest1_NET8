namespace Client.Models.SMEnum
{
    public enum ETransactionStatus
    {
        CREATED,
        CASH_IN,
        CASH_OUT,
        TERMINATED,
        ABORTED,
        ERROR
    }
}
//public class TransactionList
//{
//    [JsonIgnore]
//    public static string CREATED = "CREATED";
//    [JsonIgnore]
//    public static string CASH_IN = "CASH_IN";
//    [JsonIgnore]
//    public static string CASH_OUT = "CASH_OUT";
//    [JsonIgnore]
//    public static string TERMINATED = "TERMINATED";
//    [JsonIgnore]
//    public static string ABORTED = "ABORTED";
//    [JsonIgnore]
//    public static string ERROR = "ERROR";
//    [JsonProperty("statusList")]
//    public List<string> StatusList { get; set; } = new List<string>();

//    // Obtained from Reflection 
//    public override string ToString()
//    {
//        return string.Join("|", this.GetItemValue());
//    }
//}