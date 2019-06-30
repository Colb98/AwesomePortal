using AwesomePortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Models
{
    public class ThoiGian
    {
        public int thu { get; set; }
        public int tietBatDau { get; set; }
        public int tietKetThuc { get; set; }

        public static ThoiGian Parse(Object o)
        {
            ThoiGian ans = new ThoiGian();
            ans.thu = JsonGetter.getInt(o.ToString(), "thu");
            string[] tiet = JsonGetter.getString(o.ToString(), "tiet").Split('-');
            ans.tietBatDau = Int32.Parse(tiet[0]);
            ans.tietKetThuc = Int32.Parse(tiet[1]);
            return ans;
        }
    }
}
