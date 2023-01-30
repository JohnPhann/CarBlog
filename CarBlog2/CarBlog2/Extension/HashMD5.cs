
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;


namespace CarBlog2.Extension
{
    public static class HashMD5
    {

        public static string toMD5(this string str) {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach(byte b in bHash)
                sbHash.Append(String.Format("{0:x2}",b));
            return sbHash.ToString();

        }
    }
}
