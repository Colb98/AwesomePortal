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
            try
            {
                string ans = "";
                JObject a = JObject.Parse(json);
                ans = (string)a[attrName];
                return ans;
            }
            catch (ArgumentNullException ex)
            {
                return "";
            }
        }

        public static int getInt(string json, string attrName)
        {
            try
            {
                JObject a = JObject.Parse(json);
                JToken token = a.GetValue(attrName);
                return (int)token;
            }
            catch (ArgumentNullException ex)
            {
                return 0;
            }
        }
        public static float getFloat(string json, string attrName)
        {
            try
            {
                JObject a = JObject.Parse(json);
                JToken token = a.GetValue(attrName);
                return (float)token;
            }
            catch (ArgumentNullException ex)
            {
                return 0f;
            }
        }

        public static bool getBool(string json, string attrName)
        {
            try
            {
                JObject a = JObject.Parse(json);
                JToken token = a.GetValue(attrName);
                return (bool)token;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }

        public static string fromObject(Object o)
        {
            JObject ans = JObject.FromObject(o);
            return ans.ToString();
        }

        public static Object getObject(string json, string attrName)
        {
            JObject a = JObject.Parse(json);
            JToken token = a.GetValue(attrName);
            return (Object)token;
        }
        public static List<Object> getList(string json, string attrName)
        {
            try
            {
                JObject a = JObject.Parse(json);
                JToken token = a.GetValue(attrName);
                if (token == null || token.Type == JTokenType.Null)
                    return new List<object>();
                JArray array = (JArray)token;
                return new List<object>(array);
            }
            catch(ArgumentNullException ex)
            {
                return new List<object>();
            }
        }
    }
}
