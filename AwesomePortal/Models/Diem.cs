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

        public Diem(float gk, float ck)
        {
            giuaKy = gk;
            cuoiKy = ck;
        }

        public static Diem Parse(Object o)
        {
            Diem ans = new Diem(0, 0);
            ans.cuoiKy = JsonGetter.getFloat(o.ToString(), "ck");
            ans.giuaKy = JsonGetter.getFloat(o.ToString(), "gk");
            return ans;
        }
    }
}
