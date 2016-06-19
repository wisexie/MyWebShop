﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Helpers
{
    public static class StringExtensions
    {
        public static string TrimSafe(this string s)
        {
            return s == null ? string.Empty : s.Trim();
        }
        public static bool Contains(this string source, string value, StringComparison comparison)
        {
            return source.IndexOf(value, comparison) >= 0;
        }
    }
}