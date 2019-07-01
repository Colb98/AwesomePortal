using AwesomePortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.API.Response
{
    class BaseResponse
    {
        public bool status { get; set; }
        public Object obj { get; set; }
        
        public BaseResponse()
        {

        }

        public BaseResponse(Object jsonObject)
        {
            this.status = Parse(jsonObject).status;
        }

        public static BaseResponse Parse(Object o) => Parse(o.ToString());

        public static BaseResponse Parse(String json)
        {
            BaseResponse ans = new BaseResponse();
            JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();
            ans.status = JsonGetter.getBool(json, jsonAttr.RES_STATUS());
            ans.obj = JsonGetter.getObject(json, jsonAttr.RES_DATA());
            return ans;
        }
    }
}
