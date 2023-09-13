namespace BlazorWebAsm.MissingHistoricalRecord.DevCode;

public static class Extension
{
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
    public static string ToDigitMyanmar(this int num)
    {
        string result = num.ToString();
        result = result.Replace("0", "၀");
        result = result.Replace("1", "၁");
        result = result.Replace("2", "၂");
        result = result.Replace("3", "၃");
        result = result.Replace("4", "၄");
        result = result.Replace("5", "၅");
        result = result.Replace("6", "၆");
        result = result.Replace("7", "၇");
        result = result.Replace("8", "၈");
        result = result.Replace("9", "၉");
        return result;
    }
}