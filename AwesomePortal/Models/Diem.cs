using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Models
{
    class Diem
    {
        public float giuaKy { get; set; }
        public float cuoiKy { get; set; }

        public Diem(float gk, float ck)
        {
            giuaKy = gk;
            cuoiKy = ck;
        }
    }
}
