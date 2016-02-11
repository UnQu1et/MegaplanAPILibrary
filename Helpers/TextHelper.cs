using System;

namespace MegaplanAPILibrary.Helpers
{
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
