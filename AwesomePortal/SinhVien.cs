using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal
{
    class SinhVien : TaiKhoan
    {
        private string mssv;
        private string name;
        private ChuongTrinh chuongTrinh;
        private string falcuty;
        private string khoaTuyen;
        private List<DangKyHocPhan> dangKyHocPhan;

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
    }
}
