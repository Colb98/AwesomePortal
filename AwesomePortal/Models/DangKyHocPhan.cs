using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Models
{
    class DangKyHocPhan : Model
    {
        public Diem diem { get; set; }
        public HocPhan hocPhan { get; set; }
    }
}
