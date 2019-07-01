using AwesomePortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Models
{
    public class Diem
    {
        public float giuaKy { get; set; }
        public float cuoiKy { get; set; }

        public float tongKet { get; set; }

        public Diem(float gk, float ck, float tk)
        {
            giuaKy = gk;
            cuoiKy = ck;
            tongKet = tk;
        }

        public static Diem Parse(Object o)
        {
            Diem ans = new Diem(0, 0, 0);
            JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();
            ans.cuoiKy = JsonGetter.getFloat(o.ToString(), jsonAttr.D_CK());
            ans.giuaKy = JsonGetter.getFloat(o.ToString(), jsonAttr.D_GK());
            ans.tongKet = JsonGetter.getFloat(o.ToString(), jsonAttr.D_TK());
            return ans;
        }
    }
}
