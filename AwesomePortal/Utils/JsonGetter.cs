using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Utils
{
    class JsonGetter
    {
        public static string getString(string json, string attrName)
        {
            string ans = "";
            JObject a = JObject.Parse(json);
            ans = (string)a[attrName];
            return ans;
        }

        public static int getInt(string json, string attrName)
        {
            JObject a = JObject.Parse(json);
            JToken token = a.GetValue(attrName);
            return (int)token;
        }
    }
}
