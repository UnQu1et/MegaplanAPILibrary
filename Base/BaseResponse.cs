/*
 * Created by SharpDevelop.
 * User: Дмитрий
 * Date: 05.10.2015
 * Time: 16:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MegaplanAPILibrary.Base
{
	/// <summary>
	/// Description of BaseResponse.
	/// </summary>
	public abstract class BaseResponse
	{
		public ResponseStatus status {get; set;}
		public Error Error {get; set;}
	}
	
	public class ResponseStatus 
	{
		public string code {get; set;}
		public string message {get; set;}
	}
}
