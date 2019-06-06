using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal
{
    public interface TaiKhoan
    {
        bool DangNhap(string username, string password);
        bool DangXuat();
    }
}
