/*
 * Created by SharpDevelop.
 * User: Дмитрий
 * Date: 07.10.2015
 * Time: 14:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MegaplanAPILibrary
{
	/// <summary>
	/// Description of Error.
	/// </summary>
	public class Error
	{
		public string error_str { get; set; }
        public string error_detail { get; set; }
        public int error_code { get; set; }
	}
}
