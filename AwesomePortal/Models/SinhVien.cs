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
        public string mssv { get; set; }
        public string name { get; set; }
        public string chuongTrinh { get; set; }
        public string faculty { get; set; }
        public string khoaTuyen { get; set; }
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
            this.mssv = JsonGetter.getString(o.ToString(), "mssv");
            this.name = JsonGetter.getString(o.ToString(), "name");
            this.chuongTrinh = JsonGetter.getString(o.ToString(), "program");
            this.faculty = JsonGetter.getString(o.ToString(), "fal");
            this.khoaTuyen = JsonGetter.getString(o.ToString(), "year");
            this.dangKyHocPhan = DangKyHocPhan.ParseArray(JsonGetter.getList(o.ToString(), "dkhp"));
        }
    }
}
