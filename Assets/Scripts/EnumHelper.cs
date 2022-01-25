using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumHelper
{
    public static TEnum ToEnum<TEnum>(this string strEnumValue, TEnum defaultValue)
    {
        if (!System.Enum.IsDefined(typeof(TEnum), strEnumValue))
            return defaultValue;

        return (TEnum)System.Enum.Parse(typeof(TEnum), strEnumValue);
    }
}