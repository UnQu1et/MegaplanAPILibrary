/*
 * Created by SharpDevelop.
 * User: Дмитрий
 * Date: 05.10.2015
 * Time: 15:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace MegaplanAPILibrary
{
	/// <summary>
	/// Description of LoginClass.
	/// </summary>
	public static class Auth
	{
        public static string host { get; set; }
		public static string accessId {get; set;}
		public static string secretKey {get; set;}

        public static bool Login(string Login, string Password, string Host)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Host))
                return false;
            try
            {
                using (var wc = new WebClient())
                {
                    ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;
                    String password = (new Regex(@"^[a-f0-9]{32}$").IsMatch(Password))? Password : Helpers.SecurityHelper.GetMD5Hash(Password);
                    var response = wc.DownloadString("https://" + Host + "/BumsCommonApiV01/User/authorize.api?Login=" + Login + "&Password=" + password);
                    JObject json = JObject.Parse(response);
                    accessId = (string)json["data"]["AccessId"];
                    secretKey = (string)json["data"]["SecretKey"];
                    host = Host;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private static bool IgnoreCertificateErrorHandler(object sender, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslErr)
        {
            return true;
        }
    }
}
