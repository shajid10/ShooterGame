using TSF.Utilities;

namespace ShooterGame.Utils
{
    public static class Util
    {
        public static string GetRoundUpNumbersAsStringGranular(long number)
        {
            number = Helper.GetRoundUpNumbers(number);
            
            if (number < Helper.NUMBER_1_THOUSAND)
                return number.ToString();
            
            if (number >= Helper.NUMBER_1_TRILLION)
            {
                return ((number / (float)Helper.NUMBER_1_TRILLION)).ToString("0.00") + "T";
            }
            
            // if (number >= Helper.NUMBER_1_TRILLION)
            // {
            //     return ((number / (float)Helper.NUMBER_1_TRILLION)).ToString("0.00") + "T";
            // }
            
            if (number >= Helper.NUMBER_1_BILLION)
            {
                return (number / (float)Helper.NUMBER_1_BILLION) + "B";
            }
            
            if (number >= Helper.NUMBER_1_MILLION)
            {
                return (number / (float)Helper.NUMBER_1_MILLION) + "M";
            }
            
            return (number / (float)Helper.NUMBER_1_THOUSAND) + "K";
        }
    }
}