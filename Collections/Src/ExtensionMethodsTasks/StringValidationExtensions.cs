using System.Text.RegularExpressions;

namespace ExtensionMethodTasks;

public static class StringValidationExtensions
{
    public static bool IsValidEgyptianPhone(this string phone)
    {
        if (string.IsNullOrEmpty(phone))
            return false;

        return Regex.IsMatch(phone, @"^(?:\+20|0)1[0125][0-9]{8}$"); //used regex
    }

    public static bool IsValidEgyptianNationalId(this string nationalId)
    {
        if (string.IsNullOrWhiteSpace(nationalId))
            return false;

        return Regex.IsMatch(nationalId, @"^[23][0-9]{13}\z");
    }
}
