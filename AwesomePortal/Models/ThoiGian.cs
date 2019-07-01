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
            JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();
            ans.thu = JsonGetter.getInt(o.ToString(), jsonAttr.TG_THU());
            ans.tietBatDau = JsonGetter.getInt(o.ToString(), jsonAttr.TG_TIETBD());
            ans.tietKetThuc = JsonGetter.getInt(o.ToString(), jsonAttr.TG_TIETKT());
            return ans;
        }
    }
}
