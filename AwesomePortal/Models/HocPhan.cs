using AwesomePortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Models
{
    public class HocPhan
    {
        public HocPhan()
        {

        }

        public string maHocPhan { get; set; }
        public string tenHocPhan { get; set; }
        public int soTinChi { get; set; }
        public int maxSV { get; set; }
        public int daDK { get; set; }
        public List<HocPhan> hocPhanTienQuyet { get; set; }
        public ChuongTrinh chuongTrinh { get; set; }
        public string faculty { get; set; }
        public string namHoc { get; set; }
        public int hocKy { get; set; }
        public ThoiGian thoiGian { get; set; }

        public static HocPhan Parse(Object jsonObject)
        {
            string json = jsonObject.ToString();
            HocPhan ans = new HocPhan();
            ans.maHocPhan = JsonGetter.getString(json, "maHP");
            ans.tenHocPhan = JsonGetter.getString(json, "tenHP");
            ans.namHoc = JsonGetter.getString(json, "namHoc");
            ans.maxSV = JsonGetter.getInt(json, "maxSV");
            ans.daDK = JsonGetter.getInt(json, "dkSV");
            ans.soTinChi = JsonGetter.getInt(json, "soTC");
            ans.hocKy = JsonGetter.getInt(json, "hocKy");
            ans.thoiGian = ThoiGian.Parse(jsonObject);

            return ans;
        }

        public override string ToString()
        {
            return
                "Mã: " + maHocPhan + " Tên HP: " + tenHocPhan + " maxSV: " + maxSV;
        }
    }
}
