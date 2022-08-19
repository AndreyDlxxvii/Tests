using UnityEngine;

public static class Extension
{
    private static readonly string[] GroupPostfixes = {
        string.Empty, "K", "M", "B", "T", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "ll", "mm", "nn",
        "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"
    };

    public static string NumReduction(this ulong num, int startDigits = 5)
    {
        startDigits = Mathf.Clamp(startDigits, 4, int.MaxValue);
        int count = 0;

        ulong inputNum = num;
        while (inputNum >= 1000L)
        {
            inputNum /= 1000L;
            count++;
        }

        long categoryDigits = 1;
        ulong categoryRemainder = inputNum;
        while (categoryRemainder >= 10L)
        {
            categoryRemainder /= 10L;
            categoryDigits++;
        }

        if (count * 3 + categoryDigits < startDigits)
        {
            return num.ToString();
        }

        float subgroupRatio = num / Mathf.Pow(1000.0f, count) - 0.001f;
        if (subgroupRatio > 0.0f)
        {
            return $"{subgroupRatio:#.#}{GroupPostfixes[count]}";
        }

        return $"{inputNum:0}{GroupPostfixes[count]}";
    }
    public static bool HasMethod(this object objectToCheck, string methodName)
    {
        var type = objectToCheck.GetType();
        return type.GetMethod(methodName) != null;
    }
}