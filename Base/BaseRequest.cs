﻿using System;
using System.Reflection;

namespace MegaplanAPILibrary.Base
{
    public abstract class BaseRequest<T1>
	{
		public abstract string Uri { get; }
        public abstract string HTTPMethod { get; }
        public T1 Pars { get; set; }
        public string ParsString { get { return GetParamsString(Pars); } }

        public string GetParamsString(T1 Pars)
        {
            string result = "?";
            PropertyInfo[] pars = Pars.GetType().GetProperties();
            for (int i = 0; i < pars.Length; i++)
            {
                if (!HasValue(pars[i].GetValue(Pars, null)))
                {
                    continue;
                }
                result += pars[i].Name + "=" + pars[i].GetValue(Pars, null) + "&";
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        private bool HasValue(object obj)
        {
            string objStr = obj.ToString();
            if (String.IsNullOrEmpty(objStr) || objStr == "0" || objStr == "False")
            {
                return false;
            }
            return true;
        }
	}
}
