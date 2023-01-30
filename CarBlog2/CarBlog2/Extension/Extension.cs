using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace CarBlog2.Extension
{
    public static class Extension
    {
        public static string ToVnd(this double donGia) {

            return donGia.ToString("#,##0") + " d";
        }

        public static string ToUrlFriendly(this string url)
        {

            var result = url.ToLower().Trim();
            result = Regex.Replace(result, "ầ", "a");

            return result;

        }
    }
}
