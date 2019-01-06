using System;

namespace System
{
    public static class StringExtensions
    {
        public static string Cut (this String obj)
        {
            if (obj.Length >= 15)
                return obj.Substring(0, 15);
            else
                return obj;
        }

        public static string ToCnpjFormat (this String obj)
        {
            if (!obj.Trim().Length.Equals(18))
                return obj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            else
                return obj;
        }
    }
}