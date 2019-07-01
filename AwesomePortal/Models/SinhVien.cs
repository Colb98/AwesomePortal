using AwesomePortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Models
{
    public class SinhVien : TaiKhoan
    {
        private static SinhVien instance;
        public int id { get; set; }
        public string mssv { get; set; }
        public string name { get; set; }
        public string chuongTrinh { get; set; }
        public string faculty { get; set; }
        public string khoaTuyen { get; set; }
        public int maxTC { get; set; }
        public List<DangKyHocPhan> dangKyHocPhan { get; set; }

        private SinhVien()
        {
            dangKyHocPhan = new List<DangKyHocPhan>();
        }

        public static SinhVien getInstance()
        {
            if (instance == null)
                instance = new SinhVien();
            return instance;
        }
        public override string ToString()
        {
            return "MSSV: " + mssv + Environment.NewLine +
                "Tên: " + name + Environment.NewLine +
                "Chương trình: " + Enum.GetName(chuongTrinh.GetType(), chuongTrinh) + Environment.NewLine +
                "Khoá tuyển: " + khoaTuyen;
        }

        public bool DangNhap(string username, string password)
        {
            bool loginSuccess = LoginHelper.login(username, password);
            if(loginSuccess)
            {
                LogHelper.Log("Sinh vien logged in");
                LogHelper.Log(this.ToString());
            }
            else
            {
                LogHelper.Log("Sinh vien log in failed");
            }
            return loginSuccess;
        }

        public bool DangXuat()
        {
            LogHelper.Log("Sinh vien logged out");
            return true;
        }
        
        // Parse and copy from object
        public void GetDataFromObject(Object o)
        {
            JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();
            Object data = JsonGetter.getObject(o.ToString(), jsonAttr.SV());
            this.id = JsonGetter.getInt(data.ToString(), jsonAttr.SV_ID());
            this.mssv = JsonGetter.getString(data.ToString(), jsonAttr.SV_MSSV());
            this.name = JsonGetter.getString(data.ToString(), jsonAttr.SV_TEN());
            this.chuongTrinh = JsonGetter.getString(data.ToString(), jsonAttr.SV_CHUONGTRINH());
            this.faculty = JsonGetter.getString(data.ToString(), jsonAttr.SV_KHOA());
            this.khoaTuyen = JsonGetter.getString(data.ToString(), jsonAttr.SV_KHOATUYEN());
            this.maxTC = JsonGetter.getInt(data.ToString(), jsonAttr.SV_MAXTC());
            this.dangKyHocPhan = DangKyHocPhan.ParseArray(JsonGetter.getList(o.ToString(), jsonAttr.SV_DKHP()));
        }
    }
}
