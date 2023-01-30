using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarBlog2.Helpers
{
    public static class Utilities
    {
        public static int PAGE_SIZE = 20;

        public static async Task<string> UploadFile(Microsoft.AspNetCore.Http.IFormFile file,  string sDirectory , string path, string newname = null)
        {
            try
            {
                if (newname == null) newname = file.FileName;
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", sDirectory, newname);
                string path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", sDirectory);
                if (!System.IO.Directory.Exists(path2))
                {
                    System.IO.Directory.CreateDirectory(path2);

                }
                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt.ToLower())) // khac cac file dinh nghia
                {
                    return null;

                }
                else
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                    }
                    return newname;

                }

            }
            catch {
                return null;
            }
        }

        public static string GetRandomKey(int length = 5)
        {


            string pattern = "!@#$%^&*~abcdefghijklmnopqrstuvwxyz0123456789";
            Random rd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {

                sb.Append(pattern[rd.Next(0, pattern.Length)]);
            }

            return sb.ToString();
        }

        public static string SEOurl(string url)
        {

            url = url.ToLower();
            url = Regex.Replace(url, @"[áàạãắằặẵấầẫậảẩẳâ]", "a");
            url = Regex.Replace(url, @"[éèẹẽếềễệẻể]", "e");
            url = Regex.Replace(url, @"[óòọõốồộỗớờởợổ]", "o");
            url = Regex.Replace(url, @"[íìịiĩỉ]", "i");
            url = Regex.Replace(url, @"[ýỳỵỹỷ]", "y");
            url = Regex.Replace(url, @"[ủùúũửữừứự]", "u");
            url = Regex.Replace(url, @"[đ]", "d");

            //2. Chỉ cho phép nhận:[0-9z-z-\s]
            url = Regex.Replace(url.Trim(), @"[^-9a-z-\s]", "").Trim();
            //xử lý nhiều hơn 1 khoảng trắng ----> 1 kí
            url = Regex.Replace(url.Trim(), @"\s+", "-");
            // thay khoang trắng hàng
            url = Regex.Replace(url, @"\s", "-");
            while (true)
            {
                if (url.IndexOf("--") != -1)
                {
                    url = url.Replace("--", "-");


                }
                else
                {

                    break;
                }
            }
            return url;
        }
    }

}

 