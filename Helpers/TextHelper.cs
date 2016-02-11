/*
 * Created by SharpDevelop.
 * User: Дмитрий
 * Date: 08.10.2015
 * Time: 19:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security.Cryptography.X509Certificates;

namespace MegaplanAPILibrary.Helpers
{
	/// <summary>
	/// Description of TextHelper.
	/// </summary>
	public static class TextHelper
	{
		public static string getSubjectTypeName(string name) {
			string outputName = String.Empty;
			switch (name) {
				case "task":
					outputName = "Задача";
					break;
				case "project":
					outputName = "Проект";
					break;
				case "employee":
					outputName = "Сотрудник";
					break;
				case "comment":
					outputName = "Комментарий";
					break;
			}
			return outputName;
		}

	    public static string getNotifyLink(string host, string type, string id)
	    {
	        return "https://" + host + "/inbox/" + type + "/" + id;
	    }
	}
}
