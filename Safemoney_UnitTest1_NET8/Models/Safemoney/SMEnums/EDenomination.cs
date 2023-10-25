namespace Client.Models.Safemoney.SMEnum
{
    public enum EurDenomination
    {
        Eur_01 = 1,
        Eur_02 = 2,
        Eur_05 = 5,
        Eur_10 = 10,
        Eur_20 = 20,
        Eur_50 = 50,
        Eur_100 = 100,
        Eur_200 = 200,
        Eur_500 = 500,
        Eur_1000 = 1000,
        Eur_2000 = 2000,
        Eur_5000 = 5000,
        Eur_10000 = 10000,
        Eur_20000 = 20000,
        Eur_50000 = 50000
    }
    public class EDenomination
    {
        public static double ToDouble(EurDenomination denomination)
        {
            return (double)denomination / 100;
        }
    }
}

