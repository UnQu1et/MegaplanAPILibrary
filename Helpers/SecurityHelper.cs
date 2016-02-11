using System;
using System.Text;
using System.Security.Cryptography;

namespace MegaplanAPILibrary.Helpers
{
	public static class SecurityHelper
	{
		public static String GetMD5Hash(string value)
		{
			byte[] data;
			using (MD5 md5 = new MD5CryptoServiceProvider())
				data = md5.ComputeHash(Encoding.Default.GetBytes(value));
			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++) {
				sBuilder.Append(data[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}
		
		public static String GetHMACSHA1Hash(string value, string key) {
			byte[] data;
			using (HMACSHA1 sha1 = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
				data = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));
			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++) {
				sBuilder.Append(data[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}
		
		public static String GetBase64Hash(string value) {
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
		}

        public static string XOREncrypt(string value, int key)
        {
            string result = "";
            for (int i = 0; i < value.Length; i++)
                result += (char)(value[i] ^ key);
            return result;
        }

        public static string XORDecrypt(string value, int key)
        {
            return XOREncrypt(value, key);
        }
    }
}
