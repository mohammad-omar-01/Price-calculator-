namespace PriceCalculator
{
    public static class StringFormatter
    {
        public static string FormatPercentage(this double value)
        {
            return Math.Round(value, 2).ToString("%0.00");

        }
        public static string FormatRegularValue(this double value)
        {
            return Math.Round(value, 2).ToString("0.00");

        }


    }
}
