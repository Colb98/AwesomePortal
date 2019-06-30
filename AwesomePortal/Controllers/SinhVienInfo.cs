using AwesomePortal.Models;
using AwesomePortal.Utils;
using AwesomePortal.Utils.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Controllers
{
    class SinhVienInfo
    {
        // Ngành học
        public string nganh { get; set; }
        // Năm học
        public string nam { get; set; }
        // Số tín chỉ tối đa
        public string maxTC { get; set; }
        // Số môn đã đk
        public string curCount { get; set; }

        public override string ToString()
        {
            return "Nganh: " + nganh + " nam: " + nam + " maxTC: " + maxTC + " curCount: " + curCount;
        }
    }

    class SinhVienInfoCreator
    {
        SinhVien sv;
        public SinhVienInfoCreator(SinhVien sv)
        {
            this.sv = sv;
        }

        public async Task<SinhVienInfo> getOveralInfo()
        {
            try
            {
                BaseConnector connector = BaseConnector.getInstance();
                SinhVienInfo info = new SinhVienInfo();
                info.nganh = sv.faculty;
                // Lấy năm hiện tại
                info.nam = JsonGetter.getString((await connector.GetObject("nam")).ToString(), "nam");
                // Lấy số tín chỉ tối đa
                info.maxTC = JsonGetter.getString((await connector.GetObject("maxtc")).ToString(), "val");
                info.curCount = getCurCount(info.nam);
                return info;
            }
            catch(Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }

        private string getCurCount(string nam)
        {
            int count = 0;
            for(int i = 0; i < sv.dangKyHocPhan.Count; i++)
            {
                if (sv.dangKyHocPhan[i].hocPhan.namHoc.Equals(nam))
                    count++;
            }
            return count.ToString();
        }

        public async Task<SinhVien> GetSinhVienDetailAsync()
        {
            try
            {
                BaseConnector connector = BaseConnector.getInstance();
                sv.GetDataFromObject(await connector.GetObject("sinhvien"));
                return sv;
            }
            catch (Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }
    }
}
