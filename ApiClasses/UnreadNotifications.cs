/*
 * Created by SharpDevelop.
 * User: Дмитрий
 * Date: 07.10.2015
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MPNotificator.ApiClasses
{
	/// <summary>
	/// Description of UnreadNotifications.
	/// </summary>
	public class UnreadNotifications
	{
		public bool? Group {get; set;}
		public string TimeUpdated {get; set;}
		public int? Limit {get; set;}
		public int? Offset {get; set;}
	}
}
