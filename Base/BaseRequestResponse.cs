using System;
using System.Net;
using System.IO;
using MegaplanAPILibrary.Helpers;
using Newtonsoft.Json;

namespace MegaplanAPILibrary.Base
{
	public abstract class BaseRequestResponse<T1, T2, T3> where T1 : BaseRequest<T3> where T2 : BaseResponse
	{
		private static bool IgnoreCertificateErrorHandler(object sender,System.Security.Cryptography.X509Certificates.X509Certificate cert,System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslErr)
        {
            return true;
        }
        private string XAuth;
        private string AccessId = Auth.accessId;
        private string SecretKey = Auth.secretKey;
        private string ApiHost = Auth.host;
		public T1 Request {get; set;}
		public Error Error { get; set; }
		public T2 SendRequest() {
			System.Globalization.CultureInfo en = new System.Globalization.CultureInfo("en-US");
			Error = null;
			var date = DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss +0300", en);
            var parsString = Request.ParsString;
			ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;
			XAuth = Request.HTTPMethod+"\n\n\n"+date+"\n"+ApiHost+Request.Uri+parsString;
			XAuth = SecurityHelper.GetHMACSHA1Hash(XAuth, SecretKey);
			XAuth = AccessId+":"+SecurityHelper.GetBase64Hash(XAuth);
			WebClient wc = new WebClient();
			wc.Headers.Add("X-Sdf-Date", date);
			wc.Headers.Add("Accept", "application/json");
			wc.Headers.Add("X-Authorization", XAuth);
			var result = wc.DownloadString("https://"+ApiHost+Request.Uri+parsString);
            wc.Dispose();
			return JsonConvert.DeserializeObject<T2>(result);
		}
	}
}
