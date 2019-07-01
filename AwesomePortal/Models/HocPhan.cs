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

        public int id { get; set; }
        public string maHocPhan { get; set; }
        public string tenHocPhan { get; set; }
        public int soTinChi { get; set; }
        public int maxSV { get; set; }
        public int daDK { get; set; }
        public List<HocPhan> hocPhanTienQuyet { get; set; }
        public ChuongTrinh chuongTrinh { get; set; }
        public string faculty { get; set; }
        public int nam { get; set; }
        public string namHoc { get; set; }
        public int hocKy { get; set; }
        public string lop { get; set; }
        public ThoiGian thoiGian { get; set; }

        public static HocPhan Parse(Object jsonObject)
        {
            string json = jsonObject.ToString();
            HocPhan ans = new HocPhan();
            JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();

            ans.id = JsonGetter.getInt(json, jsonAttr.HP_ID());
            ans.maHocPhan = JsonGetter.getString(json, jsonAttr.HP_MA());
            ans.tenHocPhan = JsonGetter.getString(json, jsonAttr.HP_TEN());
            ans.nam = JsonGetter.getInt(json, jsonAttr.HP_NAM());
            ans.maxSV = JsonGetter.getInt(json, jsonAttr.HP_MAXSV());
            ans.daDK = JsonGetter.getInt(json, jsonAttr.HP_DK());
            ans.soTinChi = JsonGetter.getInt(json, jsonAttr.HP_SOTC());
            ans.hocKy = JsonGetter.getInt(json, jsonAttr.HP_HOCKY());
            ans.lop = JsonGetter.getString(json, jsonAttr.HP_LOP());
            ans.thoiGian = ThoiGian.Parse(jsonObject);

            ans.namHoc = ans.nam.ToString() + " - " + (ans.nam + 1).ToString();

            return ans;
        }

        public override string ToString()
        {
            return
                "Mã: " + maHocPhan + " Tên HP: " + tenHocPhan + " maxSV: " + maxSV;
        }
    }
}
