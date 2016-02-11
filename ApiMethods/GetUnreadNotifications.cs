/*
 * Created by SharpDevelop.
 * User: Дмитрий
 * Date: 07.10.2015
 * Time: 14:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MegaplanAPILibrary.Base;
using MegaplanAPILibrary.ApiClasses;

namespace MegaplanAPILibrary.ApiMethods
{
	/// <summary>
	/// Description of GetUnreadNotifications.
	/// </summary>
	public class GetUnreadNotifications : BaseRequestResponse<GetUnreadNotificationsRequest, GetUnreadNotificationsResponse, GetUnreadNotificationsRequest.Params>
	{
	}
	
	public class GetUnreadNotificationsRequest : BaseRequest<GetUnreadNotificationsRequest.Params>
	{
		public override string Uri {get {return "/BumsCommonApiV01/Informer/notifications.api";}}
        public override string HTTPMethod { get { return "GET"; } }
        public class Params
        {
            public bool Group { get; set; }
            public string TimeUpdated { get; set; }
            public int Limit { get; set; }
            public int Offset { get; set; }
        }
	}
	
	public class GetUnreadNotificationsResponse : BaseResponse
	{
		public GetUnreadNotificationsResponseData data {get; set;}
	}
	
	public class GetUnreadNotificationsResponseData
    {
		public Notification[] notifications {get; set;}
	}
}
