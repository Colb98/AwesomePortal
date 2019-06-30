using AwesomePortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Models
{
    public class DangKyHocPhan
    {
        public Diem diem { get; set; }
        public HocPhan hocPhan { get; set; }
        
        public static List<DangKyHocPhan> ParseArray(List<Object> o)
        {
            List<DangKyHocPhan> ans = new List<DangKyHocPhan>();
            for (int i = 0; i < o.Count; i++)
                ans.Add(DangKyHocPhan.Parse(o[i]));
            return ans;
        }

        public static DangKyHocPhan Parse(Object o)
        {
            DangKyHocPhan ans = new DangKyHocPhan();
            ans.diem = Diem.Parse(JsonGetter.getObject(o.ToString(), "diem"));
            ans.hocPhan = HocPhan.Parse(JsonGetter.getObject(o.ToString(), "hocphan"));
            return ans;
        }
    }
}
